using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesonalShopSolution.ViewModels
{
    public class CreateCart
    {
        public int Id { get; set; }
        public int? IdProduct { get; set; }
        public int IdUser { get; set; }

        public int? Amount { get; set; }
    }
}
