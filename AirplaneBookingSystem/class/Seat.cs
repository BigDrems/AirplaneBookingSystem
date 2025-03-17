using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneBookingSystem
{
    public class Seat
    {
        public string SeatNumber { get; set; }
        public bool isBooked { get; set; }
        public string ClassType { get; set; }

        public Seat(string seatNum,string classType) 
        { 
            SeatNumber = seatNum;
            isBooked = false;
            ClassType = classType;
        }

    }
}
