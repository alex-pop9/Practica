using ProiectPractica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPractica.Repository
{
    internal interface IRepository
    {
        public Configurare GetConfigurareFromString(string filePath);
    }
}
