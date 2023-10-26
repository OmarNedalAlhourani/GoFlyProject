using GoFly.Models.SharedProp;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFly.BL.Models.HomePage
{
    public class HotTour : CommonProp

    {
        public int HotTourId { get; set; }

        public string? HotTourName { get; set; }

        public string? TitelDescription { get; set; }

        public string? HotTourDescription { get; set; }

        public string? HotTourPrise { get; set; }

		[NotMapped]
        public IFormFile? Image { get; set; }

		public string? ImagePath { get; set; }





	}
}
