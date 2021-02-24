
using Carpenters.Kata.Angular.Models;
using System.Collections.Generic;

namespace Carpenters.Kata.Angular.Services.Interfaces
{
    public interface IBookingService
    {
        IList<Booking> GetAllBookings();

        void CreateBooking(Booking booking);

        void EditBooking(Booking booking);
    }
}