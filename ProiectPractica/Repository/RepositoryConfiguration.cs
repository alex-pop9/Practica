using ProiectPractica.Model;
using Newtonsoft.Json;

namespace ProiectPractica.Repository
{
    public class RepositoryConfiguration : IRepositoryConfiguration
    {
        private readonly string _filePath;
        public RepositoryConfiguration(string filePath) 
        { 
            _filePath = filePath;
        }

        /// <summary>
        /// This function deserializes a JSON string and returns the configuration.
        /// If the string can't be deserialized it returns a null object
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>The configuration from the file, if it can be deserialized or null otherwise</returns>
        public Configuration? GetConfigurationFromFile()
        {
            var stringFromFile = ReadFromFile();
            try
            {
                var configuration = JsonConvert.DeserializeObject<Configuration>(stringFromFile);
                return configuration;
            }
            catch 
            {
                return null; 
            }
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
