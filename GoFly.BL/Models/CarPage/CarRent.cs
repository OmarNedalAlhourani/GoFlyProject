using GoFly.Models.SharedProp;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFly.BL.Models.CarPage
{
    public class CarRent:CommonProp
    {
        public int CarRentId { get; set; }

        public string? CarRentTitel { get; set; }

        public String? PriseDay { get; set; }
        public String? PriseWeek { get; set; }
        public String? PriseMonth { get; set; }

        public decimal Tax { get; set; }
		[NotMapped]

		public IFormFile? Image { get; set; }

        public string? ImagePath { get; set; }
    }
}
