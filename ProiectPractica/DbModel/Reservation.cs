using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPractica.DbModel
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int Week {  get; set; }
        public float Price { get; set; }
        public float Distance { get; set; }
        public float PricePerKm { get; set; }
        public string CongirmedTime { get; set; }
        public string Currency {  get; set; }
    }
}
