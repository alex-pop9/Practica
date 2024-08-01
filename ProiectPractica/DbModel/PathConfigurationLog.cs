using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPractica.DbModel
{
    public class PathConfigurationLog
    {
        public int PathConfigurationLogID { get; set; }
        public int FileSettingsID { get; set; }
        public int ConfigurationLogID { get; set; }
        public virtual ConfigurationLog ConfigurationLog { get; set; }
        public virtual FileSettings FileSettings { get; set; }
    }
}
