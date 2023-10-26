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
    public class TodayFlight:CommonProp
    {
        public int TodayFlightId { get; set; }

        public string? Titel { get; set; }

        public string? Description { get; set; }


		public string? AirLine { get; set; }

		public string? Location { get; set; }

		public string? Date { get; set; }

		public string? Prise { get; set; }


	}
}
