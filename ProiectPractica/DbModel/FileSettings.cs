using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProiectPractica.DbModel
{
    public class FileSettings
    {
        public int FileSettingsID {  get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public virtual ICollection<PathConfigurationLog> PathConfigurations { get; set; }
    }
}
