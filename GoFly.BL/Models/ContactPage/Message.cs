using GoFly.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFly.BL.Models.ContactPage
{
    public class Message:CommonProp
    {
        public int MessageId { get; set; }
        [Required]
        public string? UserName { get; set; }
		[Required]

		public string? UserEmail { get; set; }
		[Required]

		public string? UserMassage { get; set; } = null;
    }
}
