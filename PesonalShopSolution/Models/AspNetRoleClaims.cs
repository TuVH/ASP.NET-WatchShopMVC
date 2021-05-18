using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesonalShopSolution.Models
{
    public class AspNetRoleClaims : IdentityRoleClaim<int>
    {
        public virtual AspNetRoles Role { get; set; }
    }
}
