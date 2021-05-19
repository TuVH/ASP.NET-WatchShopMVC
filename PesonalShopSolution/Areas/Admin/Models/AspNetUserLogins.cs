using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Areas.Admin.Models
{
    public partial class AspNetUserLogins : IdentityUserLogin<int>
    {
        public virtual AspNetUsers User { get; set; }
    }
}
