using ProiectPractica.Model;

namespace ProiectPractica.Repository
{
    internal interface IRepositoryConfigurare
    {
        public Configurare? GetConfigurareFromFile();
        public Configurare? SaveConfigurare(Configurare configurare);
    }
}
