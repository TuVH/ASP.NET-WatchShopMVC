using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesonalShopSolution.Areas.Admin.Models
{
    public class AspNetUserToken : IdentityUserToken<int>
    {
        public virtual AspNetUsers User { get; set; }
    }
}
