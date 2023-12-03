using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinicApplication
{/// <summary>
/// Contains information fields about patient
/// </summary>
    public class PatientModel
    {
        #region Properties
        public Guid PatientID { get; set; }
        public string PatientName { get; set; }
        public Gender PatientGender{ get; set; }
        public DateTime PatientAppointmentDate { get; set; }
        
        public double PatientAge { get; set; }
        public string PatientSpecies { get; set; }

        public string PatientOwner { get; set; }

        public string PatientOwnerContactNumber { get; set; }

        public int  PatientAppointmentNumbet { get;set; }
        public string PatientDoctor { get; set; } 

        public string PatientDisease { get; set; }

        public string  PatientLegend { get; set; }

        public string PatientTreatment { get; set; }

        #endregion
        public override string ToString()
        {
            return $"ID: {PatientID},Appointment Date: {PatientAppointmentDate}, Name: {PatientName}, Age: {PatientAge}, Species: {PatientSpecies}, Disease: {PatientDisease},Owner: {PatientOwner}, " +
                $"Contact Number: {PatientOwnerContactNumber}, Disease History: {PatientLegend}" +
                $"Appointment Number: {PatientAppointmentNumbet}, Doctor: {PatientDoctor}," +
                $"Treatment: {PatientTreatment}";
        }
        
    }
}
