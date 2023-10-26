using GoFly.Models.SharedProp;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFly.BL.Models.vacationPage
{
	public class TouristSpots:CommonProp
	{
        public int TouristSpotsId { get; set; }

        public string? TouristSpotsTitel { get; set; }

        public string? TouristSpotsDescription { get; set; }

        public string? Prise { get; set; }
		[NotMapped]

		public IFormFile? Image { get; set; }

        public string? ImagePath { get; set; }
    }
}
