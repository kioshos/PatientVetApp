using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VetClinicApplication;

namespace VetClinicApplication
{   /// <summary>
    /// Contains information about new added patients
    /// </summary>
    public class AddPatientModel
    {
        private MainViewModel _mainViewModel;
        private Action _closeAction;

        #region Private properties
        private Guid _newPatientID;
        private string _newPatientName;
        private Gender _newPatientGender;
        private double _newPatientAge;
        private string _newPatientSpecies;
        private string _newPatientOwner;
        private string _newPatientContact;
        private int _newPatientAppointmentNumber;
        private string _newPatientDoctor;
        private string _newPatientDisease;
        //private string _newPatientGender;
        private string _newPatientLegend;
        private string _newPatientTreatment;
        private DateTime _selectedDate;
        private ObservableCollection<Gender> _genderValues;
        private ObservableCollection<VetClinicDoctors> _doctorsValues;
        #endregion


        #region Public properties
        public Guid NewPatientID
        {
            get { return _newPatientID; }
            set
            {
                _newPatientID = value;
                OnPropertyChanged(nameof(NewPatientID));
            }
        }
        public DateTime NewPatientAppointmentDate
        {
            get { return (DateTime)_selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(NewPatientAppointmentDate));
            }
        }
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));

            }
        }
        public ObservableCollection<Gender> GenderValues
        {
            get { return _genderValues; }
            set
            {
                if (!Equals(_genderValues, value))
                {
                    _genderValues = value;
                    OnPropertyChanged(nameof(GenderValues));
                }
            }
        }
        public ObservableCollection<VetClinicDoctors> DoctorsValues
        {
            get { return _doctorsValues; }
            set
            {
                if (!Equals(_doctorsValues, value))
                {
                    _doctorsValues = value;
                    OnPropertyChanged(nameof(DoctorsValues));
                }
            }
        }
        public string NewPatientName
        {
            get { return _newPatientName; }
            set
            {
                _newPatientName = value;
                OnPropertyChanged(nameof(NewPatientName));
            }
        }
        public Gender NewPatientGender
        {
            get { return _newPatientGender; }
            set
            {
                _newPatientGender = value;
                OnPropertyChanged(nameof(NewPatientGender));
            }
        }
        public string NewPatientTreatment
        {
            get { return _newPatientTreatment; }
            set
            {
                _newPatientTreatment = value;
                OnPropertyChanged(nameof(NewPatientTreatment));
            }
        }
        public double NewPatientAge
        {
            get { return _newPatientAge; }
            set
            {
                _newPatientAge = value;
                OnPropertyChanged(nameof(NewPatientAge));
            }
        }

        public string NewPatientSpecies
        {
            get { return _newPatientSpecies; }
            set
            {
                _newPatientSpecies = value;
                OnPropertyChanged(nameof(NewPatientSpecies));
            }
        }

        public string NewPatientOwner
        {
            get { return _newPatientOwner; }
            set
            {
                _newPatientOwner = value;
                OnPropertyChanged(nameof(NewPatientOwner));
            }
        }

        public string NewPatientContact
        {
            get { return _newPatientContact; }
            set
            {
                _newPatientContact = value;
                OnPropertyChanged(nameof(NewPatientContact));
            }
        }
        public int NewPatientAppointmentNumber
        {
            get { return _newPatientAppointmentNumber; }
            set
            {
                _newPatientAppointmentNumber = value;
                OnPropertyChanged(nameof(NewPatientAppointmentNumber));
            }
        }

        public string NewPatientDoctor
        {
            get { return _newPatientDoctor; }
            set
            {
                _newPatientDoctor = value;
                OnPropertyChanged(nameof(NewPatientDoctor));
            }
        }

        public string NewPatientDisease
        {
            get { return _newPatientDisease; }
            set
            {
                _newPatientDisease = value;
                OnPropertyChanged(nameof(NewPatientDisease));
            }
        }

        public string NewPatientLegend
        {
            get { return _newPatientLegend; }
            set
            {
                _newPatientLegend = value;
                OnPropertyChanged(nameof(NewPatientLegend));
            }
        }
        #endregion
        public ICommand AddPatientCommand { get; private set; }

        public AddPatientModel(MainViewModel mainViewModel, Action closeAction)
        {
            _mainViewModel = mainViewModel;
            _closeAction = closeAction;
            SelectedDate = DateTime.Now;

            // Initialization a new commands
            AddPatientCommand = new RelayCommand(AddPatient);
            GenderValues = new ObservableCollection<Gender>(Enum.GetValues(typeof(Gender)).Cast<Gender>());
            DoctorsValues = new ObservableCollection<VetClinicDoctors>(Enum.GetValues(typeof(VetClinicDoctors)).Cast<VetClinicDoctors>());
        }


        // Add new patient
        private void AddPatient()
        {

            PatientViewModel newPatient = new PatientViewModel
            {
                PatientID = Guid.NewGuid(),
                PatientAppointmentDate = NewPatientAppointmentDate,
                PatientName = NewPatientName,
                PatientGender = NewPatientGender,
                PatientAge = NewPatientAge,
                PatientSpecies = NewPatientSpecies,
                PatientOwner = NewPatientOwner,
                PatientOwnerContactNumber = NewPatientContact,
                PatientAppointmentNumber = NewPatientAppointmentNumber,
                PatientDoctor = NewPatientDoctor,
                PatientDisease = NewPatientDisease,
                PatientTreatment = NewPatientTreatment,
                PatientLegend = NewPatientLegend


            };

            try
            {
                if (newPatient.PatientName != null)
                {
                    _mainViewModel.AddPatient(newPatient);

                    DataStorage.SaveData(_mainViewModel.Patients);


                    ClearFields();
                }
                else
                {
                    MessageBox.Show("A field cannot be empty");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        #region Private Helper
        private void ClearFields()
        {
            NewPatientName = string.Empty;
            NewPatientAge = 0;
            NewPatientSpecies = string.Empty;
            NewPatientOwner = string.Empty;
            NewPatientAppointmentNumber = 0;
            NewPatientDisease = string.Empty;
            NewPatientTreatment = string.Empty;
            NewPatientLegend = string.Empty;

        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
