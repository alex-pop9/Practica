using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectPractica.Model;

namespace ProiectPractica.Persistance
{
    public interface IConfigurationPersistence
    {
        public Configuration? Save(Configuration configuration, string filePath);
        public Configuration? GetLastConfigurationFromFile(string filePath, out int id);
        public Configuration? GetPreviousConfiguration(string filePath, int curentId, out int previousId);
        public Configuration? GetNextConfiguration(string filePath, int currentId, out int nextId);
        public int GetLastConfigurationIndexByFile(string filePath);
        public int GetFirstConfigurationIndexByFile(string filePath);
        public List<Configuration> FindAll();
    }
}
