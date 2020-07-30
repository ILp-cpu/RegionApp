using System;
using System.Collections.Generic;
using System.Text;

namespace RegionModel
{
    public class RegionVModel
    {
        public int Id { get; set; }
        public int region_id { get; set; }
        public int parent_region_id { get; set; }
        public string region_name { get; set; }

        public int m18 { get; set; }
        public int m60 { get; set; }
        public int m_over { get; set; }

        public int f18 { get; set; }
        public int f60 { get; set; }
        public int f_over { get; set; }
        public int total { get; set; }
}
}
