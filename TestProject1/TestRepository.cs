using ProiectPractica.Repository;
using ProiectPractica.Model;

namespace TestProject1
{
    [TestClass]
    public class TestRepository
    {
        [TestMethod]
        public void GetConfigurareFromFile_ValidFilePath_ReturnConfigurare()
        {
            var stubPath = "C:\\Users\\AlexandruPop\\source\\repos\\ProiectPractica\\TestProject1\\test.json";
            var repository = new RepositoryConfigurare(stubPath);

            var configurare = repository.GetConfigurareFromFile();

            Assert.IsNotNull(configurare);
        }

        [TestMethod]
        public void GetConfigurareFromFile_InvalidJson_ReturnNullConfigurare()
        {
            var stubPath = "C:\\Users\\AlexandruPop\\source\\repos\\ProiectPractica\\TestProject1\\test2.json";
            var repository = new RepositoryConfigurare(stubPath);

            var configurare = repository.GetConfigurareFromFile();

            Assert.IsNull(configurare);
        }

        [TestMethod]
        public void GetConfigurareFromFile_InvalidFilePath_ThrowException()
        {
            var stubPath = "C:\\Users\\AlexandruPop\\source\\repos\\ProiectPractica\\TestProject1\tests.json";
            var repository = new RepositoryConfigurare(stubPath);

            Assert.ThrowsException<FileNotFoundException>(() => repository.GetConfigurareFromFile());
        }

        [TestMethod]
        public void SaveConfigurare_ValidConfiguration_SaveAndReturnConfiguratie()
        {
            var stubPath = "C:\\Users\\AlexandruPop\\source\\repos\\ProiectPractica\\TestProject1\\test3.json";
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
            var stubPath = "C:\\Users\\AlexandruPop\\source\\repos\\ProiectPractica\\TestProject1\\test3.json";
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