using ProiectPractica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

namespace ProiectPractica.Repository
{
    internal class RepositoryConfigurare : IRepositoryConfigurare
    {  
        /// <summary>
        /// This function deserializes a JSON string if the string is valid and returns the configuration.
        /// If the string fails the validation or the file does not exist it returns a null object
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>The configuration from the file if it is valid or a null Configurare object otherwise</returns>
        public Configurare? GetConfigurareFromString(string filePath)
        {
            var stringFromFile = ReadFromFile(filePath);
            if (ValidateFileContent(stringFromFile))
            {
                 var configurare = JsonConvert.DeserializeObject<Configurare>(stringFromFile);
                 return configurare;
            }
            return null;
        }

        /// <summary>
        /// This function reads from a file and returns the string read from the file, if the file exists.
        /// And if the file does not exists the function throws an exception.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>The string from file</returns>
        /// <exception cref="Exception"></exception>
        private string ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found!");
            }
            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// Function that validates a string.
        /// It checks if the string is in JSON format, if the string has all the attributes 
        /// needed to be deserialized into the Configurare object and also if all attributes 
        /// have the correct data type.
        /// Throws an exception if the string does not meet any of the criteria above.
        /// </summary>
        /// <param name="stringToBeValidated"></param>
        /// <returns>True, if the string given is correct</returns>
        /// <exception cref="Exception"></exception>
        private bool ValidateFileContent(string stringToBeValidated)
        {
            var generator = new JsonSchemaGenerator();
            var schema = generator.Generate(typeof(Configurare));

            var conf = JObject.Parse(stringToBeValidated);

            IList<String> messages;
            if(!conf.IsValid(schema,out messages))
            {
                throw new Exception(messages.ToString());
            }
            return true;
        }
    }
}
