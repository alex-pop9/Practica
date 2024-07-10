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
        public int StartBusinessHour { get; set; }
        public int EndBusinessHour { get; set; }

       

        public Configurare(int minAccPrice, float minPricePerKm, int numberOfCars, 
            int reservationCheck, string phoneNumber, int minPriceShortTrip, 
            int shortTripDistance, int startBusinessHour, int endBusinessHour)
        {
            MinAcceptablePrice = minAccPrice;
            MinPricePerKm = minPricePerKm;
            NumberOFCars = numberOfCars;
            ReservationCheckInterval = reservationCheck;
            PhoneNumber = phoneNumber;
            MinPriceForShortTrips = minPriceShortTrip;
            StartBusinessHour = startBusinessHour;
            EndBusinessHour = endBusinessHour;
        }

        public Configurare() { }

    }
}
