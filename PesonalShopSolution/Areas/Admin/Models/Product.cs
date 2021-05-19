using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Areas.Admin.Models
{
    public partial class Product
    {

        public int Id { get; set; }
        public int? ProductCode { get; set; }
        public string ProductName { get; set; }
        public string DetailDescription { get; set; }
        public int? IdSpecifications { get; set; }
        public int? IdBrand { get; set; }
        public string Evaluate { get; set; }
        public string Image { get; set; }
        public int? Price { get; set; }


        public virtual Brand IdBrandNavigation { get; set; }
        public virtual Specification IdSpecificationsNavigation { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
