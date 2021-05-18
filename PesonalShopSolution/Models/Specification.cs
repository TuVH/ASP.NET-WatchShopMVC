using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Models
{
    public partial class Specification
    {
        public int IdSpecifications { get; set; }
        public int? IdBrand { get; set; }
        public string Shape { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string Weight { get; set; }
        public string Warranty { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
