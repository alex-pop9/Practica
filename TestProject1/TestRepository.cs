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
        public void GetConfigurareFromFile_ValidFilePath_ReturnConfigurare()
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            string stubPath = Path.Combine(assemblyDirectory, "configurareOK.json");
            var repository = new RepositoryConfigurare(stubPath);

            var configurare = repository.GetConfigurareFromFile();

            Assert.IsNotNull(configurare);
        }

        [TestMethod]
        public void GetConfigurareFromFile_InvalidJson_ReturnNullConfigurare()
        {
            var stubPath = "C:\\Users\\AlexandruPop\\source\\repos\\ProiectPractica\\TestProject1\\configurareInvalida.json";
            var repository = new RepositoryConfigurare(stubPath);

            var configurare = repository.GetConfigurareFromFile();

            Assert.IsNull(configurare);
        }

        [TestMethod]
        public void GetConfigurareFromFile_InvalidFilePath_ThrowException()
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            string stubPath = Path.Combine(assemblyDirectory, "configurare.json");
            var repository = new RepositoryConfigurare(stubPath);

            Assert.ThrowsException<FileNotFoundException>(() => repository.GetConfigurareFromFile());
        }

        [TestMethod]
        public void SaveConfigurare_ValidConfiguration_SaveAndReturnConfiguratie()
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            string stubPath = Path.Combine(assemblyDirectory, "configurareSave.json");
            var repository = new RepositoryConfigurare(stubPath);
            var configuration = new Configurare
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

            var configurareFromWrite = repository.SaveConfigurare(configuration);

            Assert.IsNotNull(configurareFromWrite);
        }

        [TestMethod]
        public void SaveConfigurare_InvalidPath_ThrowException()
        {
            var stubPath = "C:\\Users\\AlexandruPop\\source\\repos\\ProiectPractica\\TestProject1\test3.json";
            var repository = new RepositoryConfigurare(stubPath);
            var configuration = new Configurare
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

            Assert.ThrowsException<IOException>(() => repository.SaveConfigurare(configuration));
        }

        [TestMethod]
        public void SaveConfigurare_IncompleteConfiguration_SaveAndReturnConfiguratie()
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            string stubPath = Path.Combine(assemblyDirectory, "configurareIncompleta.json");
            var repository = new RepositoryConfigurare(stubPath);
            var configuration = new Configurare
            {
                MinAcceptablePrice = 1,
                MinPricePerKm = 2,
                NumberOfCars = 3
            };

            var configurareFromWrite = repository.SaveConfigurare(configuration);

            Assert.IsNotNull(configurareFromWrite);
        }
    }
}