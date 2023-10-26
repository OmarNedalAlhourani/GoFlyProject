using GoFly.Models.SharedProp;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFly.BL.Models.HomePage
{
    public class PopularDestination : CommonProp
    {
        public int PopularDestinationId { get; set; }

        public string? PopularDestinationName { get; set; }
		[NotMapped]
		public IFormFile? Image { get; set; }

		public string? ImagePath { get; set; }


	}
}
