using GoFly.Models.SharedProp;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFly.BL.Models.FlightsPage
{
	public class Deal:CommonProp
	{
		public int DealId { get; set; }

		public string? DealName { get; set; }

		public string? TitelDescription { get; set; }

		public string? DealDescription { get; set; }

		public string? DealPrise { get; set; }
		[NotMapped]

		public IFormFile? Image { get; set; }

		public string? ImagePath { get; set; }
	}
}
