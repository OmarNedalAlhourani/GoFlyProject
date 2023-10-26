using GoFly.Models.SharedProp;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFly.BL.Models.HotelPage
{
    public class HostelDestination:CommonProp
    {
        public int HostelDestinationId { get; set; }

        public string? HostelDestinationName { get; set; }


        public string? HostelDestinationDescription { get; set; }

        public string HostelDestinationPrise { get; set; }
		[NotMapped]

		public IFormFile? Image { get; set; }

		public string? ImagePath { get; set; }


	}
}
