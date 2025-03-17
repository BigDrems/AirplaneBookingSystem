using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneBookingSystem
{
    public class Passenger
    {
        public string PassportNumber { get; set; }
        public string Name { get; set; }

        public Passenger(string passNum,string name)
        {
            this.Name = name;
            this.PassportNumber = passNum;
        }
    }
}
