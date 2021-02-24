using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Carpenters.Kata.Angular.Models;
using Carpenters.Kata.Angular.Services;
using Carpenters.Kata.Angular.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carpenters.Kata.Angular.Controllers
{
    [ApiController]
    [Route("api/booking")]

    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = new BookingService();
        }

        [HttpGet]
        [Route("")]
        public IEnumerable Get()
        {
            //var bookingService = new BookingService();
            IEnumerable<Booking> bookings = this.bookingService.GetAllBookings();

            return bookings;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Booking booking)
        {
            try
            {
                this.bookingService.CreateBooking(booking);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Booking booking)
        {
            try
            {
                this.bookingService.EditBooking(booking);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}