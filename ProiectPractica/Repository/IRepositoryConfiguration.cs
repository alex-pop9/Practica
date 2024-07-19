using ProiectPractica.Model;

namespace ProiectPractica.Repository
{
    internal interface IRepositoryConfiguration
    {
        public Configuration? GetConfigurationFromFile();
        public Configuration? SaveConfiguration(Configuration configuration);
    }
}
