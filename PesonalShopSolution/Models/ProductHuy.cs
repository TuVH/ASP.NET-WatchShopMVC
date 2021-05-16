using System;
using System.Collections.Generic;

namespace PesonalShopSolution.Models
{
    public partial class ProductHuy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
