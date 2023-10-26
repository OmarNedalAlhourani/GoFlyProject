using GoFly.Models.SharedProp;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFly.BL.Models.HotelPage
{
    public class TravelBooking:CommonProp
    {
        public int TravelBookingId { get; set; }

        public string? TravelBookingDescription { get; set; }
		[NotMapped]

		public IFormFile? Image { get; set; }

		public string? ImagePath { get; set; }

	}
}
