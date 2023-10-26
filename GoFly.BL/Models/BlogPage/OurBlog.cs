using Azure;
using GoFly.Models.SharedProp;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFly.BL.Models.BlogPage
{
    public class OurBlog:CommonProp
    {

        public int OurBlogId { get; set; }
        public string? Titel { get; set; }

        public string? Date { get; set; }

        public string? Description { get; set; }
		[NotMapped]
        
		public IFormFile? Image { get; set; }

		public string? ImagePath { get; set; }


	}
}
