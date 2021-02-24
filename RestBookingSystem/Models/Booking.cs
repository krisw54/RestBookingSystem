using System;

namespace Carpenters.Kata.Angular.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int TableNumber { get; set; }

        public string ContactName { get; set; }

        public string ContactNumber { get; set; }

        public int NumberOfPeople { get; set; }

        public DateTime BookingTime { get; set; }
    }
}