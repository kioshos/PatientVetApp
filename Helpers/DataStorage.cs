using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;


namespace VetClinicApplication
{   /// <summary>
    /// Stores and load data from JSON fiile
    /// </summary>
    public class DataStorage
    {   // Path to the file

        private static readonly string JsonFilePath = Path.Combine(Environment.CurrentDirectory, "info.json");

        /// <summary>
        /// Save data to the JSON file
        /// </summary>
        /// <param name="patients"></param>
        public static void SaveData(ObservableCollection<PatientViewModel> patients)
        {
            try
            {
               
                string jsonData = JsonConvert.SerializeObject(patients, Formatting.Indented);
                File.WriteAllText(JsonFilePath, jsonData);

                Console.WriteLine("A patient has been added succesfully");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        /// <summary>
        /// Load information about patient from json file
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<PatientViewModel> LoadData()
        {
            ObservableCollection<PatientViewModel> patients = new ObservableCollection<PatientViewModel>();

            try
            {
                if (File.Exists(JsonFilePath))
                {
                    string jsonData = File.ReadAllText(JsonFilePath);
                    patients = JsonConvert.DeserializeObject<ObservableCollection<PatientViewModel>>(jsonData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }

            return patients;
        }
        /// <summary>
        /// Update and save data if patient has been deleted
        /// </summary>
        /// <param name="patients"></param>
        public static void SaveDelData(ObservableCollection<PatientViewModel> patients)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(patients, Formatting.Indented);
                File.WriteAllText(JsonFilePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting data: {ex.Message}");
               
            }
        }
    }

}
