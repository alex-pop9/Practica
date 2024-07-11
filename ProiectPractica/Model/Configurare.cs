using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPractica.Model
{
    internal class Configurare
    {
        public int MinAcceptablePrice { get; set; }
        public float MinPricePerKm { get; set; }
        public int NumberOFCars { get; set; }
        public int ReservationCheckInterval { get; set; }
        public string PhoneNumber { get; set; }
        public int MinPriceForShortTrips { get; set; }
        public int ShortTripDistanceThreshold { get; set; }
        public int StartBusinessHour { get; set; }
        public int EndBusinessHour { get; set; }
    }
}
