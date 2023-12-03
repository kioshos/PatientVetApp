using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VetClinicApplication
{
    public class PatientViewModel : INotifyPropertyChanged
    {
        private PatientModel _patient = new PatientModel();


        public PatientModel Patient
        {
            get { return _patient; }
            set
            {
                _patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }

        
        public Guid PatientID
        {
            get { return _patient.PatientID; }
            set
            {
                _patient.PatientID = value;
                OnPropertyChanged(nameof(PatientID));
            }
        }
        public DateTime PatientAppointmentDate
        {
            get { return (DateTime)_patient.PatientAppointmentDate; }
            set 
            {
                _patient.PatientAppointmentDate = value; 
                OnPropertyChanged(nameof(PatientAppointmentDate)); 
            }
        }
        public string PatientName
        {
            get { return _patient.PatientName; }
            set
            {
                _patient.PatientName = value;
                OnPropertyChanged(nameof(PatientName));
            }
        }
        public Gender PatientGender
        {
            get { return _patient.PatientGender; }
            set
            {
                _patient.PatientGender = value;
                OnPropertyChanged(nameof(PatientGender));
            }
        }
        public double PatientAge
        {
            get { return _patient.PatientAge; }
            set
            {
                _patient.PatientAge = value;
                OnPropertyChanged(nameof(PatientAge));
            }
        }

        public string PatientSpecies
        {
            get { return _patient.PatientSpecies; }
            set
            {
                _patient.PatientSpecies = value;
                OnPropertyChanged(nameof(PatientSpecies));
            }
        }

        public string PatientOwner
        {
            get { return _patient.PatientOwner; }
            set
            {
                _patient.PatientOwner = value;
                OnPropertyChanged(nameof(PatientOwner));
            }
        }
        public string PatientOwnerContactNumber
        {
            get { return _patient.PatientOwnerContactNumber; }
            set
            {
                _patient.PatientOwnerContactNumber = value;
                OnPropertyChanged(nameof(PatientOwnerContactNumber));
            }
        }

        public int PatientAppointmentNumber 
        { 
            get { return _patient.PatientAppointmentNumbet; }
            set 
            {
                _patient.PatientAppointmentNumbet = value;
                OnPropertyChanged(nameof(PatientAppointmentNumber));
            }
        }
        public string PatientDoctor
        {
            get { return _patient.PatientDoctor; }
            set
            {
                _patient.PatientDoctor = value;
                OnPropertyChanged(nameof(PatientDoctor));
            }
        }

        public string PatientDisease
        {
            get { return _patient.PatientDisease; }
            set
            {
                _patient.PatientDisease = value;
                OnPropertyChanged(nameof(PatientDisease));
            }
        } 

        public string PatientLegend
        {
            get { return _patient.PatientLegend; }
            set
            {
                _patient.PatientLegend = value;
                OnPropertyChanged(nameof(PatientLegend));
            }
        }

        public string PatientTreatment
        {
            get { return _patient.PatientTreatment; }
            set
            {
                _patient.PatientTreatment = value;
                OnPropertyChanged(nameof(PatientTreatment));
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
