using ProiectPractica.Repository;
using ProiectPractica.Model;
using System.IO;
using System.Reflection;
using Mono.Cecil;

namespace TestProject1
{
    [TestClass]
    public class TestRepository
    {
        [TestMethod]
        public void GetConfigurationFromFile_ValidFilePath_ReturnConfiguration()
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            var stubPath = Path.Combine(assemblyDirectory, "ConfigurationsForTest", "validConfiguration.json");
            var repository = new ConfigurationRepository(stubPath);

            var configuration = repository.GetConfigurationFromFile();

            Assert.IsNotNull(configuration);
        }

        [TestMethod]
        public void GetConfigurationFromFile_InvalidJson_ReturnNullConfiguration()
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            var stubPath = Path.Combine(assemblyDirectory, "ConfigurationsForTest", "invalidConfiguration.json");
            var repository = new ConfigurationRepository(stubPath);

            var configuration = repository.GetConfigurationFromFile();

            Assert.IsNull(configuration);
        }

        [TestMethod]
        public void GetConfigurationFromFile_InvalidFilePath_ThrowException()
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            var stubPath = Path.Combine(assemblyDirectory, "configuration.json");
            var repository = new ConfigurationRepository(stubPath);

            Assert.ThrowsException<FileNotFoundException>(() => repository.GetConfigurationFromFile());
        }

        [TestMethod]
        public void SaveConfiguration_ValidConfiguration_SaveAndReturnConfiguration()
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            var stubPath = Path.Combine(assemblyDirectory, "ConfigurationsForTest", "saveConfiguration.json");
            var repository = new ConfigurationRepository(stubPath);
            var configuration = new Configuration
            {
                MinAcceptablePrice = 1,
                MinPricePerKm = 2,
                NumberOfCars = 3,
                ReservationCheckInterval = 4,
                PhoneNumber = "+12345",
                MinPriceForShortTrips = 6,
                ShortTripDistanceThreshold = 7,
                StartBusinessHour = 8,
                EndBusinessHour = 9
            };

            var configurationFromWrite = repository.SaveConfiguration(configuration);

            Assert.IsNotNull(configurationFromWrite);
        }

        [TestMethod]
        public void SaveConfiguration_InvalidPath_ThrowException()
        {
            // Here I gave an actual invalid file path, because using the method from other tests
            // will create the file, failing the test.
            var stubPath = "C:\test3.json";
            var repository = new ConfigurationRepository(stubPath);
            var configuration = new Configuration
            {
                MinAcceptablePrice = 1,
                MinPricePerKm = 2,
                NumberOfCars = 3,
                ReservationCheckInterval = 4,
                PhoneNumber = "+12345",
                MinPriceForShortTrips = 6,
                ShortTripDistanceThreshold = 7,
                StartBusinessHour = 8,
                EndBusinessHour = 9
            };

            Assert.ThrowsException<IOException>(() => repository.SaveConfiguration(configuration));
        }

        [TestMethod]
        public void SaveConfiguration_IncompleteConfiguration_SaveAndReturnConfiguration()
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            var stubPath = Path.Combine(assemblyDirectory, "ConfigurationsForTest", "incompleteConfiguration.json");
            var repository = new ConfigurationRepository(stubPath);
            var configuration = new Configuration
            {
                MinAcceptablePrice = 1,
                MinPricePerKm = 2,
                NumberOfCars = 3
            };

            var configurationFromWrite = repository.SaveConfiguration(configuration);

            Assert.IsNotNull(configurationFromWrite);
        }
    }
}