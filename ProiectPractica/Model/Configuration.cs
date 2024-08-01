using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPractica.Model
{
    public class Configuration
    {
        public int MinAcceptablePrice { get; set; }
        public float MinPricePerKm { get; set; }
        public int NumberOfCars { get; set; }
        public int ReservationCheckInterval { get; set; }
        public string PhoneNumber { get; set; }
        public int MinPriceForShortTrips { get; set; }
        public int ShortTripDistanceThreshold { get; set; }
        public int StartBusinessHour { get; set; }
        public int EndBusinessHour { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Configuration configuration &&
                   MinAcceptablePrice == configuration.MinAcceptablePrice &&
                   MinPricePerKm == configuration.MinPricePerKm &&
                   NumberOfCars == configuration.NumberOfCars &&
                   ReservationCheckInterval == configuration.ReservationCheckInterval &&
                   PhoneNumber == configuration.PhoneNumber &&
                   MinPriceForShortTrips == configuration.MinPriceForShortTrips &&
                   ShortTripDistanceThreshold == configuration.ShortTripDistanceThreshold &&
                   StartBusinessHour == configuration.StartBusinessHour &&
                   EndBusinessHour == configuration.EndBusinessHour;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(MinAcceptablePrice);
            hash.Add(MinPricePerKm);
            hash.Add(NumberOfCars);
            hash.Add(ReservationCheckInterval);
            hash.Add(PhoneNumber);
            hash.Add(MinPriceForShortTrips);
            hash.Add(ShortTripDistanceThreshold);
            hash.Add(StartBusinessHour);
            hash.Add(EndBusinessHour);
            return hash.ToHashCode();
        }
    }
}
