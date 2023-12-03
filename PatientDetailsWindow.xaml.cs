using System.Windows;

namespace VetClinicApplication
{
    public partial class PatientDetailsWindow : Window
    {
        public PatientDetailsWindow(PatientViewModel patient)
        {
            InitializeComponent();

           
            PatientIDTextBlock.Text = $"ID: {patient.PatientID}";
            NameTextBlock.Text = $"Name: {patient.PatientName}";
            AgeTextBlock.Text = $"Age: {patient.PatientAge}";
            SpeciesTextBlock.Text = $"Species: {patient.PatientSpecies}";
            OwnerTextBlock.Text = $"Owner: {patient.PatientOwner}";
            ContactTextBlock.Text = $"Contact Information: {patient.PatientOwnerContactNumber}";
            AppNumTextBlock.Text = $"Appointment number: {patient.PatientAppointmentNumber}";
            DoctorTextBlock.Text = $"Doctor: {patient.PatientDoctor}";
            DiseaseTextBlock.Text = $"Disease: {patient.PatientDisease}";
            DiseaseHTextBlock.Text = $"History: {patient.PatientLegend}";
            TreatmentTextBlock.Text = $"Treatment: {patient.PatientTreatment}";
           
  
        }

        private void OnOkButtonClick(object sender, RoutedEventArgs e)
        {
            
            Close();
        }
    }
}
