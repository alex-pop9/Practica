using Newtonsoft.Json;
using ProiectPractica.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPractica.SettingsHandler
{
    public class FileSettingsHandler
    {
        private string _filePath { get; set; }

        public FileSettingsHandler(string fileName)
        {
            _filePath = fileName;
        }

        /// <summary>
        /// Returns the FileSettings from the file.
        /// </summary>
        /// <returns></returns>
        public FileSettings? GetFileSettings()
        {
            try
            {
                var textFromFile = ReadFromFile();
                var fileSettings = JsonConvert.DeserializeObject<FileSettings>(textFromFile);
                return fileSettings;
            }
            catch
            {
                return null; 
            }
        }
        
        /// <summary>
        /// Saves the FileSettings into the file.
        /// </summary>
        /// <param name="fileSettings"></param>
        /// <returns></returns>
        public FileSettings? Save(FileSettings fileSettings)
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(fileSettings, Formatting.Indented));
            return fileSettings;
        }

        private string ReadFromFile()
        {
            return File.ReadAllText(_filePath);
        }
    }
}
