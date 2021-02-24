using Carpenters.Kata.Angular.Services.Interfaces;
using System.Collections.Generic;
using System.Web;
using Carpenters.Kata.Angular.Models;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Data.SQLite;
using System;

namespace Carpenters.Kata.Angular.Services
{
    public class DataService : IDataService
    {
        private static IList<Booking> bookings;
        private static string databLocation = @"URI=file:" + Directory.GetCurrentDirectory() + "/bookingsDatabase.db";

        public IList<Booking> Initialize()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "/bookingsDatabase.db"))
            {
                createDatabase();
            }

            using var con = new SQLiteConnection(databLocation);
            con.Open();

            string stm = "SELECT * FROM restaurantBookings";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            bookings = new List<Booking>();
            while (rdr.Read())
            {
                bookings.Add(new Booking
                {
                    BookingId = rdr.GetInt32(0),
                    TableNumber = rdr.GetInt32(1),
                    ContactName = rdr.GetString(2),
                    ContactNumber = rdr.GetString(3),
                    NumberOfPeople = rdr.GetInt32(4),
                    BookingTime = DateTime.Parse(rdr.GetString(5))
                }
               );
            }

            return bookings;

        }

        IList<Booking> FallbackJsonData()
        {

            using (StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + "/json/bookings.json"))
            {
                string json = r.ReadToEnd();
                bookings = JsonConvert.DeserializeObject<List<Booking>>(json);
            }
            return bookings;

        }

        void createDatabase()
        {

            using var con = new SQLiteConnection(databLocation);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"CREATE TABLE restaurantBookings (id INTEGER PRIMARY KEY,
                    tableNo INT, contactName TEXT, contactNumber TEXT, diners INT, dateTime TEXT )";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO restaurantBookings(tableNo, contactName, contactNumber, diners, dateTime ) " +
                "VALUES(1, 'David Thompson', '07111222331', 4, '2019-03-25T13:00:00.000Z')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO restaurantBookings(tableNo, contactName, contactNumber, diners, dateTime ) " +
                "VALUES(3, 'James Gartland', '07111222332', 1, '2019-03-25T15:00:00.000Z')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO restaurantBookings(tableNo, contactName, contactNumber, diners, dateTime ) " +
                 "VALUES(2, 'Stephen Hewitt', '07111222333', 3, '2019-03-25T14:00:00.000Z')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO restaurantBookings(tableNo, contactName, contactNumber, diners, dateTime ) " +
                "VALUES(4, 'Colin Hughes', '07111222334', 10, '2019-03-25T10:30:00.000Z')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO restaurantBookings(tableNo, contactName, contactNumber, diners, dateTime ) " +
                "VALUES(3, 'Richard Blears', '07111222335', 6, '2019-03-25T20:15:00.000Z')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO restaurantBookings(tableNo, contactName, contactNumber, diners, dateTime ) " +
                "VALUES(1, 'James Edgson', '07111222336', 7, '2019-03-25T20:00:00.000Z')";
            cmd.ExecuteNonQuery();

        }
    }
}