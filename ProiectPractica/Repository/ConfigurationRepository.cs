using ProiectPractica.Model;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace ProiectPractica.Repository
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private string _filePath;

        /// <summary>
        /// This function deserializes a JSON string and returns the configuration.
        /// If the string can't be deserialized it returns a null object
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>The configuration from the file, if it can be deserialized or null otherwise</returns>
        public Configuration? GetConfigurationFromFile()
        {
            try
            {
                var stringFromFile = ReadFromFile();
                var configuration = JsonConvert.DeserializeObject<Configuration>(stringFromFile);
                return configuration;
            }
            catch 
            {
                return null; 
            }
        }

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        /// <summary>
        /// Save the given configuration into the file.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public Configuration? SaveConfiguration(Configuration configuration)
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(configuration, Formatting.Indented));
            return configuration;
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
