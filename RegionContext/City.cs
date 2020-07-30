using System;
using System.Collections.Generic;

namespace RegionContext
{
    public partial class City
    {
        public City()
        {
            RouteFromCity = new HashSet<Route>();
            RouteToCity = new HashSet<Route>();
        }

        public int Id { get; set; }
        public int RegionId { get; set; }
        public string CityName { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Route> RouteFromCity { get; set; }
        public virtual ICollection<Route> RouteToCity { get; set; }
    }
}
