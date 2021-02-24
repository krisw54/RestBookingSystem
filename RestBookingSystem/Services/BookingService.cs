using Carpenters.Kata.Angular.Models;
using Carpenters.Kata.Angular.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Carpenters.Kata.Angular.Services
{
    public class BookingService : IBookingService
    {
        private static string databaseLocation = @"URI=file:" + Directory.GetCurrentDirectory() + "/bookingsDatabase.db";
        private static IList<Booking> bookings;

        public BookingService() : this(new DataService())
        {
        }

        public BookingService(IDataService dataService)
        {
            bookings = dataService.Initialize();
        }

        public IList<Booking> GetAllBookings()
        {
            return bookings;
        }

        private void ValidateBooking(Booking booking)
        {
            if (booking.TableNumber > 4)
            {
                throw new ArgumentOutOfRangeException("Table number " + booking.TableNumber + " does not exist");
            }
            if (booking.TableNumber < 1)
            {
                throw new ArgumentOutOfRangeException("Table number " + booking.TableNumber + " does not exist");
            }
        }


        public void CreateBooking(Booking booking)
        {
            try
            {
                ValidateBooking(booking);
            }
            catch
            {
                throw;
            }

            using var con = new SQLiteConnection(databaseLocation);
            con.Open();

            using var cmd = new SQLiteCommand(con);
            cmd.CommandText = "INSERT INTO restaurantBookings(tableNo, contactName, contactNumber, diners, dateTime)" +
                " VALUES(@tableNo, @contactName, @contactNumber, @diners, @dateTime)";

            cmd.Parameters.AddWithValue("@tableNo", booking.TableNumber);
            cmd.Parameters.AddWithValue("@contactName", booking.ContactName);
            cmd.Parameters.AddWithValue("@contactNumber", booking.ContactNumber);
            cmd.Parameters.AddWithValue("@diners", booking.NumberOfPeople);
            cmd.Parameters.AddWithValue("@dateTime", booking.BookingTime.ToString());
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Console.WriteLine("row inserted");
        }

        public void EditBooking(Booking booking)
        {

            ValidateBooking(booking);

            using var con = new SQLiteConnection(databaseLocation);
            con.Open();

            using var cmd = new SQLiteCommand(con);
            cmd.CommandText = "UPDATE restaurantBookings" +
                " SET tableNo = @tableNo, contactName = @contactName, contactNumber = @contactNumber, diners = @diners, dateTime = @dateTime" +
                " WHERE id = @id";

            cmd.Parameters.AddWithValue("@id", booking.BookingId);
            cmd.Parameters.AddWithValue("@tableNo", booking.TableNumber);
            cmd.Parameters.AddWithValue("@contactName", booking.ContactName);
            cmd.Parameters.AddWithValue("@contactNumber", booking.ContactNumber);
            cmd.Parameters.AddWithValue("@diners", booking.NumberOfPeople);
            cmd.Parameters.AddWithValue("@dateTime", booking.BookingTime.ToString());
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Console.WriteLine("row updated");
        }


    }
}