using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelerikAspNetCoreApp2.Models
{
    public class OrderViewModel
    {
		public int OrderID
		{
			get;
			set;
		}

		public decimal? Freight
		{
			get;
			set;
		}

		[Required]
		public DateTime? OrderDate
		{
			get;
			set;
		}

		public string ShipCity
		{
			get;
			set;
		}

		public string ShipName
		{
			get;
			set;
		}
	}

    public class User22
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
