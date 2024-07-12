using ProiectPractica.Model;

namespace ProiectPractica.Repository
{
    internal interface IRepositoryConfigurare
    {
        public Configurare GetConfigurareFromString(string filePath);
    }
}
