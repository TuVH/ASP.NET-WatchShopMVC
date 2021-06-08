using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Areas.Admin.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int? IdProduct { get; set; }
        public int IdUser { get; set; }

        public int? Amount { get; set; }
       

        public virtual Product IdProductNavigation { get; set; }
        public virtual AspNetUsers IdUserNavigation { get; set; }

    }
}
