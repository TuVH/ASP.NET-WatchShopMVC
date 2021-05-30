using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Areas.Admin.Models
{
    public partial class OrderDetails
    {

        public int IdOrderDetails { get; set; }
        public int IdOrder { get; set; }
        public string Amount { get; set; }
        public string DiscountCode { get; set; }
        public int? IdProduct { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual Order IdOrdersNavigation { get; set; }
       
    }
}
