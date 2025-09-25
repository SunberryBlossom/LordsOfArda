using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LordsOfArda.Saving
{
    public class SaveMaster
    {
        private string _saveDirectory = @".\Saves";
        public SaveMaster()
        {
            // Ensure the save directory exists
            if (!Directory.Exists(_saveDirectory))
            {
                Directory.CreateDirectory(_saveDirectory);
            }
        }
        // Method to save the game state to a file
        public bool SaveGame(SaveData saveData)
        {
            var date = DateTime.Now;
            string saveFolder = Path.Combine(_saveDirectory, saveData.UUID);
            string saveFile = $"save_{date.Year}{date.Month}{date.Day}_{date.Hour}{date.Minute}.json";
            // If unique character savefolder does not exist, create it
            if (!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
            }
            // Serialize the SaveData object to JSON and write it to a file with date_time
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
            Console.WriteLine(Path.Combine(saveFolder, saveFile));
            try
            {
                Console.WriteLine(Path.Combine(saveFolder, saveFile));
                var json = JsonSerializer.Serialize(saveData,options);
                File.WriteAllText(Path.Combine(saveFolder,saveFile), json);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving game" + e);
                return false;
            }
        }
        // Method to load the game state from a file
        public SaveData LoadGame(string saveName)
        {
            // saveName should contain full reference to json file
            try
            {
                var loadedData = JsonSerializer.Deserialize<SaveData>(File.ReadAllText(saveName));
                return loadedData;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error loading game: " + e);
                throw;
            }
        }

        public List<SaveData> GetAllSaves()
        {
            return new List<SaveData>();
        }
    }
}
