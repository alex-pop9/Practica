using ProiectPractica.Model;

namespace ProiectPractica.Repository
{
    internal interface IConfigurationRepository
    {
        public Configuration? GetConfigurationFromFile();
        public Configuration? SaveConfiguration(Configuration configuration);
    }
}
