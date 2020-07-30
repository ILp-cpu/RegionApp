using System;
using System.Collections.Generic;
using System.Text;

namespace RegionModel
{
    public class RouteVModel
    {
        public int Id { get; set; }

        public string from_city { get; set; }
        public string to_city { get; set; }

        public int m18 { get; set; }
        public int m60 { get; set; }
        public int m_over { get; set; }

        public int f18 { get; set; }
        public int f60 { get; set; }
        public int f_over { get; set; }
        public int total { get; set; }
    }
}
