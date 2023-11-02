using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFly.BL.Models.SharedProp
{
	public class SearchSeared
	{
		public DateTime? CheckIn { get; set; }
		public DateTime CheckOut { get; set; }


		public int Adult { get; set; }

		public int Children { get; set; }
	}
}
