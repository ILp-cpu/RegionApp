using System;
using System.Collections.Generic;

namespace TelerikAspNetCoreApp2.Models
{
    public class Route
    {
        public int Id { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public int UserId { get; set; }
        public DateTime? EventDate { get; set; }

        public virtual Users User { get; set; }
        public virtual City FromCity { get; set; }
        public virtual City ToCity { get; set; }
    }
}
