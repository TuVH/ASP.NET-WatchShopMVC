using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PesonalShopSolution.ViewModels
{
    public class CreateOrder
    {
        public DateTime? OrderDate { get; set; }
        public int IdUser { get; set; }
        public int TotalMoney { get; set; }

        public int IdOrder { get; set; }
        [Required]
        public string Amount { get; set; }
        public string DiscountCode { get; set; }
        public int? IdProduct { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
