﻿using ProiectPractica.Model;
using Newtonsoft.Json;

namespace ProiectPractica.Repository
{
    public class RepositoryConfigurare : IRepositoryConfigurare
    {
        private readonly string _filePath;
        public RepositoryConfigurare(string filePath) 
        { 
            _filePath = filePath;
        }

        /// <summary>
        /// This function deserializes a JSON string and returns the configuration.
        /// If the string can't be deserialized it returns a null object
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>The configuration from the file, if it can be deserialized or null otherwise</returns>
        public Configurare? GetConfigurareFromFile()
        {
            var stringFromFile = ReadFromFile();
            try
            {
                var configurare = JsonConvert.DeserializeObject<Configurare>(stringFromFile);
                return configurare;
            }
            catch 
            {
                return null; 
            }
        }

        /// <summary>
        /// Save the given configurare into the file.
        /// </summary>
        /// <param name="configurare"></param>
        /// <returns></returns>
        public Configurare? SaveConfigurare(Configurare configurare)
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(configurare, Formatting.Indented));
            return configurare;
        }

        /// <summary>
        /// This function reads from a file and returns the string read from the file, if the file exists.
        /// And if the file does not exists the function throws an exception.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>The string from file</returns>
        /// <exception cref="Exception"></exception>
        private string ReadFromFile()
        {
            return File.ReadAllText(_filePath);
        }
    }
}
