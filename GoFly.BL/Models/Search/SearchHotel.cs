using GoFly.BL.Models.SharedProp;
using GoFly.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFly.BL.Models.Search
{
	public class SearchHotel:SearchSeared
	{
		public int SearchHotelId { get; set; }

		public string? City { get; set;}

        public int Room { get; set; }




    }
}
