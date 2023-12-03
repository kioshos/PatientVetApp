using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;


namespace VetClinicApplication
{
    /// <summary>
    /// View model for the main window
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PatientViewModel> _patients;
        private PatientViewModel _selectedPatient;

        public ObservableCollection<PatientViewModel> Patients
        {
            get { return _patients; }
            set
            {
                _patients = value;
                OnPropertyChanged(nameof(Patients));
            }
        }

        public PatientViewModel SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                _selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        #region Commands
        public ICommand OpenAddPatientWindowCommand { get; private set; }
        public ICommand AddPatientCommand { get; private set; }
        public ICommand RemovePatientCommand { get; private set; }
        public ICommand SaveDataCommand { get; private set; }
        public ICommand LoadDataCommand { get; private set; }
        public ICommand ShowPatientDetailsCommand { get; private set; }
        public ICommand EditPatientCommand { get; private set; }
        public ICommand ViewScheduleCommand { get; private set; }

        #endregion
        public MainViewModel()
        {
            // Initialization commands
            AddPatientCommand = new RelayCommand(AddPatient);
            RemovePatientCommand = new RelayCommand(RemovePatientAndSave);
            //SaveDataCommand = new RelayCommand(SaveData);
            LoadDataCommand = new RelayCommand(LoadData);
            EditPatientCommand = new RelayCommand(EditPatient);
           
            OpenAddPatientWindowCommand = new RelayCommand(OpenAddPatientWindow);
            ShowPatientDetailsCommand = new RelayCommand(ShowPatientDetails);

            // Initialization patients clollection
            Patients = new ObservableCollection<PatientViewModel>(DataStorage.LoadData() ?? new ObservableCollection<PatientViewModel>());
            
            
        }
  
        public void AddPatient(PatientViewModel patient)
        {
            Patients.Add(patient);
        }

       private void LoadData()
        {
            var loadedPatients = DataStorage.LoadData();
            if (loadedPatients != null)
            {
                Patients.Clear();
                foreach (var patient in loadedPatients)
                {
                    Patients.Add(patient);
                }
            }
        }

        #region Command methods
        private void AddPatient()
        {
            PatientViewModel newPatient = new PatientViewModel();
      
           
            if (!Patients.Any(p => p.PatientID == newPatient.PatientID))
            {
                Patients.Add(newPatient);

             
                DataStorage.SaveData(Patients);
            }
            else
            {
                
                MessageBox.Show("That patient is already exist");
            }
        }
       
        private void EditPatient()
        {
            if (SelectedPatient != null)
            {
                
                EditPatientViewModel editViewModel = new EditPatientViewModel(SelectedPatient, () => { });
                EditPatientWindow editWindow = new EditPatientWindow();

                editWindow.DataContext = editViewModel;

              
                editWindow.ShowDialog();
            }
        }

        private void RemovePatientAndSave()
        {
            if (SelectedPatient != null)
            {
               
                Patients.Remove(SelectedPatient);

                
                DataStorage.SaveDelData(Patients);
            }
        }
        private void OpenAddPatientWindow()
        {
            
            AddPatientWindow addPatientWindow = null;

            AddPatientModel viewModel = null;

            Action closeAction = () => addPatientWindow?.Close();

            addPatientWindow = new AddPatientWindow(this, closeAction);
            viewModel = new AddPatientModel(this, closeAction);

            addPatientWindow.DataContext = viewModel;


            if (addPatientWindow.ShowDialog() == true) ;
            
        }
        private void ShowPatientDetails()
        {
            if (SelectedPatient != null)
            {
                
                PatientDetailsWindow detailsWindow = new PatientDetailsWindow(SelectedPatient);

         
                detailsWindow.ShowDialog();
            }
            else
            {
               
                MessageBox.Show("Choose the patient for view details");
            }
        }
      

        
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
