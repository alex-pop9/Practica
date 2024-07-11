using ProiectPractica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProiectPractica.Repository
{
    internal class RepositoryConfigurare
    {
        /// <summary>
        /// this function reads from a file and returns the string read from the file, if the file exists
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>a string</returns>
        private string ReadFromFile(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                return "";
            }
            return File.ReadAllText(filePath);
        }
        /// <summary>
        /// it takes the string from ReadFromFile,and if is not empty, it makes a Configurare object, deserializing the string 
        /// if it is empty it returns an empty object Configurare
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Configurare</returns>
        public Configurare GetConfugurareFromString(string filePath)
        {
            string stringFromFile = ReadFromFile(filePath);
            if(stringFromFile == "")
            {
                return new Configurare();
            }
            Configurare configurare = JsonConvert.DeserializeObject<Configurare>(stringFromFile);
            return configurare;
        }
    }
}
