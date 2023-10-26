using GoFly.Models.SharedProp;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFly.BL.Models.HomePage
{
    public class Plan : CommonProp
    {
        public int PlanId { get; set; }

        public string? PlanTitel { get; set; }

        public string? PlanDescription { get; set; }
		[NotMapped]

		public IFormFile? Image { get; set; }

		public string? ImagePath { get; set; }


	}
}
