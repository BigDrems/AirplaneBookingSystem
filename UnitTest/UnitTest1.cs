using System;
using AirplaneBookingSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class PassengerTests
    {
     
        [TestMethod]
        public void Passenger_CreatesPassengerWithCorrectDetails()
        {
            var name = "Jack Fiel";
            var passNum = "312AD";

            var passenger = new Passenger(passNum,name);

            Assert.AreEqual(name,passenger.Name);
            Assert.AreEqual(passNum,passenger.PassportNumber);

        }
    }

    [TestClass]
    public class BookingTests
    {
        [TestMethod]
        public void Booking_CreateBookingWithCorrectDetails()
        {
            var passenger = new Passenger("Jack Fiel", "123DS");
            var seat = new Seat("2A", "Business");

            var booking = new Booking(passenger, seat);

            Assert.AreEqual(booking.Passenger, passenger);
            Assert.AreEqual(booking.BookingDate.Date, DateTime.Now.Date);
            Assert.IsFalse(string.IsNullOrEmpty(booking.BookingReference));

        }

    }
    [TestClass]

    public class FlightBookingSystemTests
    {
        [TestMethod]
        public void InitializeSeats_CreateCorrectNumberOfSeats()
        {
            var flightSystem = new FlightBookingSystem();
            var seats = flightSystem.GetAvailableSeats();

            Assert.AreEqual(6, seats.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(BookingException))]
        public void BookSeat_ThrowsException_WhenSeatIsEmpty()
        {
            var system = new FlightBookingSystem();
            var passenger = new Passenger("Israel", "123VC");

            system.BookSeat(" ", passenger);
        }

        [TestMethod]
        [ExpectedException(typeof(BookingException))]
        public void BookSeat_ThrowsException_WhenPassengerIsNull()
        {
            var system = new FlightBookingSystem();

            system.BookSeat("1A", null);
        }

        [TestMethod]
        [ExpectedException(typeof(BookingException))]

        public void BookSeat_ThrowsException_WhenSeatDoesNotExist()
        {
            var system = new FlightBookingSystem();
            var passenger = new Passenger("Digong", "3030");

            system.BookSeat("10A", passenger);
        }

        [TestMethod]
        [ExpectedException(typeof(SeatIsNotAvailable))]
        public void BookSeat_ThrowsException_WhenSeatIsAlreadyBooked()
        {
            var system = new FlightBookingSystem();
            var passenger = new Passenger("James", "123C");

            system.BookSeat("1A", passenger);
            system.BookSeat("1A", passenger);
        }
        [TestMethod]
        public void BookSeat_GetAvailableSeats()
        {
            var system = new FlightBookingSystem();
            var seats = system.GetAvailableSeats();

            Assert.AreEqual(6, seats.Count);
        }
        [TestMethod]
        public void BookSeat_BookSeatSuccessfully()
        {
            var system = new FlightBookingSystem();
            var passenger = new Passenger("Lebron", "231LD");
            var booking = system.BookSeat("1A", passenger);

            Assert.IsNotNull(booking);
            Assert.AreEqual("1A", booking.Seat.SeatNumber);
            Assert.AreEqual(passenger, booking.Passenger);
        }

        [TestMethod]
        public void BookSeat_BookSeatGetBooking()
        {
            var system = new FlightBookingSystem();
            var passenger = new Passenger("Tabada", "516C");
            var booking = system.BookSeat("1A", passenger);

            var getBook = system.GetBooking(booking.BookingReference);
            Assert.AreEqual(booking, getBook);
        }
    }

    [TestClass]
    public class SeatTests
    {
        [TestMethod]
        public void Seat_InitializeSeat()
        {
            var setNum = "1A";
            var classType = "First";

            var system = new FlightBookingSystem();
            var seats = new Seat(setNum, classType);

            Assert.AreEqual(seats.SeatNumber, setNum);
            Assert.AreEqual(seats.ClassType,classType);
        }
    }
}
