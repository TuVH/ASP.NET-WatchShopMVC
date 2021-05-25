using PesonalShopSolution.Areas.Admin.Models;
using PesonalShopSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesonalShopSolution.ViewModels
{
    public class CreateRoleViewModel
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public IEnumerable<AspNetUsers> AspNetUsers { get; set; }
    }
}
