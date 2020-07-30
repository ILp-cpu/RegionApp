using System;
using System.Collections.Generic;

namespace TelerikAspNetCoreApp2.Models
{
    public class Users
    {
        public Users()
        {
            Route = new HashSet<Route>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Route> Route { get; set; }
    }
}
