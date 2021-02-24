using System.Collections.Generic;
using System;
using NUnit.Framework;
using Carpenters.Kata.Angular.Services.Interfaces;
using Carpenters.Kata.Angular.Models;
using Carpenters.Kata.Angular.Services;
using Moq;

namespace Tests
{
    public class BookingServiceTests
    {
        private IBookingService bookingService;
        private Mock<IDataService> dataServiceMock;
        private IList<Booking> bookings;

        [SetUp]
        public void Initialize()
        {
            bookings = new List<Booking>
            {
                new Booking { BookingId = 1 },
                new Booking { BookingId = 19 },
                new Booking { BookingId = 7 },
                new Booking { BookingId = 5 }
            };

            dataServiceMock = new Mock<IDataService>();

            bookingService = new BookingService(dataServiceMock.Object);
        }

        [TearDown]

        #region Create

        [Test]
        public void CreateBooking_NullBooking_ThrowsArgumentNullException()
        {
            //Assert.ThrowsException<ArgumentNullException>(() => bookingService.CreateBooking(null));
        }

        [Test]
        public void CreateBooking_InvalidTableNumber_Zero_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var booking = new Booking
            {
                TableNumber = 0
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => bookingService.CreateBooking(booking));
        }

        [Test]
        public void CreateBooking_InvalidTableNumber_NegativeNumber_ThrowsArgumentOutOfRangeException()
        {
            var booking = new Booking
            {
                TableNumber = -1
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => bookingService.CreateBooking(booking));
        }

        [Test]
        public void CreateBooking_InvalidTableNumber_TooHigh_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var booking = new Booking
            {
                TableNumber = 5
            };

            //Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookingService.CreateBooking(booking));
        }

        [Test]
        public void CreateBooking_InvalidTableNumber_TooHigh_ThrowsArgumentOutOfRangeExceptionWithMessage()
        {
            // Arrange
            var booking = new Booking
            {
                TableNumber = 5
            };

            ArgumentOutOfRangeException exception = null;

            try
            {
                bookingService.CreateBooking(booking);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.Contains("Table number 5 does not exist"));
        }

        [Test]
        public void CreateBooking_InvalidTableNumber_TooLow_ThrowsArgumentOutOfRangeExceptionWithMessage()
        {
            // Arrange
            var booking = new Booking
            {
                TableNumber = -2
            };

            ArgumentOutOfRangeException exception = null;

            // Act
            try
            {
                bookingService.CreateBooking(booking);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                exception = ex;
            }

            // Assert
            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.Contains("Table number -2 does not exist"));
        }

        [Test]
        public void CreateBooking_Valid_BookingAddedToBookings()
        {
            // Arrange
            var booking = new Booking()
            {
                ContactName = "Banana",
                TableNumber = 1
            };

            // Act
            bookingService.CreateBooking(booking);

            // Assert
            Assert.AreEqual(5, bookingService.GetAllBookings().Count);
        }

        [Test]
        public void CreateBooking_Valid_BookingIdIncrementsMaxId()
        {
            // Arrange
            var booking = new Booking()
            {
                ContactName = "Banana",
                TableNumber = 1
            };

            // Act
            bookingService.CreateBooking(booking);

            // Assert
            Assert.AreEqual(5, bookingService.GetAllBookings().Count);
            Assert.AreEqual(20, bookingService.GetAllBookings()[4].BookingId);
        }

        #endregion Create        
    }
}