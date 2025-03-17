using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneBookingSystem
{
    public class SeatIsNotAvailable:Exception
    {
        public SeatIsNotAvailable(string seatnum) : base($"Seat {seatnum} is not available"){}
    }
}
