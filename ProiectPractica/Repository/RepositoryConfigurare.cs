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
    internal class RepositoryConfigurare : IRepository
    {
        /// <summary>
        ///  This function reads from a file and returns the string read from the file, if the file exists.
        ///  And if the file does not exists the function throws an exception.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception("File not found!");
            }
            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// This function deserializes a JSON string if the string is valid and returns the configuration.
        /// If the string fails the validation or the file does not exist it returns an empty object
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>The configuration from the file if it is valid or an empty Configurare object otherwise</returns>
        public Configurare GetConfigurareFromString(string filePath)
        {
            try
            {
                var stringFromFile = ReadFromFile(filePath);
                if (ValidateString(stringFromFile))
                {
                     var configurare = JsonConvert.DeserializeObject<Configurare>(stringFromFile);
                     return configurare;
                }
                return new Configurare();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);// sa adaug un logger in cazul in care am erori de genul?
                return new Configurare();
            }
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
        private bool ValidateString(string stringToBeValidated)
        {
            JsonSchemaGenerator generator = new JsonSchemaGenerator();
            JsonSchema schema = generator.Generate(typeof(Configurare));

            JObject conf = JObject.Parse(stringToBeValidated);

            IList<String> messages;
            if(!conf.IsValid(schema,out messages))
            {
                throw new Exception(messages.ToString());
            }
            return true;
        }
    }
}
