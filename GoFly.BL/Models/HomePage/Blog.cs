using GoFly.Models.SharedProp;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFly.BL.Models.HomePage
{
    public class Blog : CommonProp
    {
        public int BlogId { get; set; }



        public string? Titel { get; set; }

        public string? Date { get; set; }

        public string? Description { get; set; }

		[NotMapped]

		public IFormFile? Image { get; set; }

        public string? ImagePath { get; set; }




	}
}
