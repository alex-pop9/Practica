using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectPractica.Model;
using ProiectPractica.DbModel;

namespace ProiectPractica.Mapper
{
    public class Mapper
    {
        public static Model.Configuration Convert(DbModel.Configuration configuration) =>
             new Model.Configuration
             {
                 MinAcceptablePrice = configuration.MinAcceptablePrice,
                 MinPricePerKm = configuration.MinPricePerKm,
                 NumberOfCars = configuration.NumberOfCars,
                 ReservationCheckInterval = configuration.ReservationCheckInterval,
                 PhoneNumber = configuration.PhoneNumber,
                 MinPriceForShortTrips = configuration.MinPriceForShortTrips,
                 ShortTripDistanceThreshold = configuration.ShortTripDistanceThreshold,
                 StartBusinessHour = configuration.StartBusinessHour,
                 EndBusinessHour = configuration.EndBusinessHour
             };

        public static DbModel.Configuration Convert(Model.Configuration configuration) =>
            new DbModel.Configuration
            {
                MinAcceptablePrice = configuration.MinAcceptablePrice,
                MinPricePerKm = configuration.MinPricePerKm,
                NumberOfCars = configuration.NumberOfCars,
                ReservationCheckInterval = configuration.ReservationCheckInterval,
                PhoneNumber = configuration.PhoneNumber,
                MinPriceForShortTrips = configuration.MinPriceForShortTrips,
                ShortTripDistanceThreshold = configuration.ShortTripDistanceThreshold,
                StartBusinessHour = configuration.StartBusinessHour,
                EndBusinessHour = configuration.EndBusinessHour
            };

        public static Model.FileSettings Convert(DbModel.FileSettings fileSettings) =>
             new Model.FileSettings { FilePath = fileSettings.FilePath };

        public static DbModel.FileSettings Convert(Model.FileSettings fileSettings) =>
            new DbModel.FileSettings
            {
                FileName = fileSettings.FilePath.Split(Path.DirectorySeparatorChar).Last(),
                FilePath = fileSettings.FilePath
            };
    }
}
