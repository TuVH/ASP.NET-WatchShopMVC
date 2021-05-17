using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Product = new HashSet<Product>();
            Specification = new HashSet<Specification>();
        }

        public int IdBrand { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Specification> Specification { get; set; }
    }
}
