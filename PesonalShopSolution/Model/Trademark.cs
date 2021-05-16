using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Model
{
    public partial class Trademark
    {
        public Trademark()
        {
            Product = new HashSet<Product>();
            Specifications = new HashSet<Specifications>();
        }

        [Key]
        [Column("Id_trademark")]
        [StringLength(10)]
        public string IdTrademark { get; set; }
        [Column("Trademark_name")]
        [StringLength(50)]
        public string TrademarkName { get; set; }

        [InverseProperty("Trademark")]
        public virtual ICollection<Product> Product { get; set; }
        [InverseProperty("Trademark")]
        public virtual ICollection<Specifications> Specifications { get; set; }
    }
}
