using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneBookingSystem
{
    public class Booking
    {
        public Passenger Passenger { get; set; }
        public Seat Seat { get; set; }  
        public DateTime BookingDate { get; set; }
        public string BookingReference { get; set; }

        public Booking (Passenger passenger, Seat seat)
        {
            Passenger = passenger;
            Seat = seat;
            BookingDate = DateTime.Now;
            BookingReference = Guid.NewGuid().ToString().Substring(0,8);
        }
 
    }
}
