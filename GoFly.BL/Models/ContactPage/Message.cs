using GoFly.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFly.BL.Models.ContactPage
{
    public class Message
    {
        public int MessageId { get; set; }
        public string? UserName { get; set; }

		public string? UserEmail { get; set; }

		public string? UserMassage { get; set; } 

        public DateTime Date { get; set; }
    }
}
