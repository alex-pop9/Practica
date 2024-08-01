using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPractica.DbModel
{
    public class ConfigurationLog
    {
        public int ConfigurationLogID {  get; set; }
        public string ConfigurationString { get; set; }
        public string TimeStamp { get; set; }
        public virtual ICollection<PathConfigurationLog> PathConfigurations { get; set; }
    }
}
