using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneBookingSystem
{
    public class FlightBookingSystem
    {
        private List<Seat> seats;
        private List<Booking> bookings;

        public FlightBookingSystem()
        {
            seats = new List<Seat>();
            bookings = new List<Booking>();
            InitializeSeats();
        }

        public void InitializeSeats()
        {
            seats.Add(new Seat("1A", "First"));
            seats.Add(new Seat("1B", "First"));
            seats.Add(new Seat("2A", "Business"));
            seats.Add(new Seat("2B", "Business"));
            seats.Add(new Seat("3A", "Economy"));
            seats.Add(new Seat("3B", "Economy"));
        }

        public Booking BookSeat(string seatNum, Passenger passenger)
        {
            if (string.IsNullOrEmpty(seatNum))
            {
                throw new BookingException("Seat Number cannot be empty");
            }

            if (passenger == null)
            {
                throw new BookingException("Passenger information is required");
            }

            var seat = seats.FirstOrDefault(s => s.SeatNumber == seatNum);

            if (seat == null)
            {
                throw new BookingException($"Seat {seatNum} does not exist");
            }

            if (seat.isBooked)
            {
                throw new SeatIsNotAvailable(seatNum);
            }

            seat.isBooked = true;
            var booking = new Booking(passenger, seat);
            bookings.Add(booking);


            return booking;
        }

        public List<Seat> GetAvailableSeats(string classType = null)
        {
            return seats
                .Where(s => !s.isBooked && (classType == null) || (classType == s.ClassType))
                .ToList();
        }

        public Booking GetBooking(string bookingReference)
        {
            return bookings.FirstOrDefault(b => b.BookingReference == bookingReference);
        }
    }
}
