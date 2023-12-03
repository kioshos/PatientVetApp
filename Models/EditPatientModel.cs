using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace VetClinicApplication
{   /// <summary>
    /// Edit information about chosen patient
    /// </summary>
    public class EditPatientModel : INotifyPropertyChanged
    {
        private PatientViewModel _patient;
        private Action _closeAction;

        public PatientViewModel Patient
        {
            get { return _patient; }
            set
            {
                _patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }

        public ICommand SaveChangesCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public EditPatientModel(PatientViewModel patient, Action closeAction)
        {
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            _closeAction = closeAction;

           SaveChangesCommand = new RelayCommand(SaveChanges);
          
        }

        private void SaveChanges()
        {
           DataStorage.SaveData(new ObservableCollection<PatientViewModel> { _patient });

            _closeAction();
           
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
