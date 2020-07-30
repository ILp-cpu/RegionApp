using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelerikAspNetCoreApp2.Models
{

    public class Region
    {
        public Region()
        {
            City = new HashSet<City>();
        }

        public int RegionId { get; set; }
        public int ParentRegionId { get; set; }
        public string RegionName { get; set; }
        public int? FeatureBindingId { get; set; }
        public int EntityTypeId { get; set; }
        public int RegionLevel { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
