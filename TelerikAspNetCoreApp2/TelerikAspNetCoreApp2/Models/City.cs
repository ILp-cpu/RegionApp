using System;
using System.Collections.Generic;

namespace TelerikAspNetCoreApp2.Models
{
    public class City
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string CityName { get; set; }

        public virtual Region Region { get; set; }
    }
}
