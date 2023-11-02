using GoFly.BL.Models.SharedProp;
using GoFly.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFly.BL.Models.Search
{
	public class SearchFlight:SearchSeared
	{
        public int SearchFlightId { get; set; }

        public string? SearchFlightFrom { get; set; }
        public string? SearchFlightTo { get; set; }

        public string? Class { get; set; }

    }
}
