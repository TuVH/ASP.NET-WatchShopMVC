using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Model
{
    public partial class Cart
    {
        [Key]
        [Column("id")]
        [StringLength(10)]
        public string Id { get; set; }
        [Column("id_product")]
        [StringLength(10)]
        public string IdProduct { get; set; }
        [Column("id_cart_details")]
        [StringLength(10)]
        public string IdCartDetails { get; set; }

        [ForeignKey(nameof(IdCartDetails))]
        [InverseProperty(nameof(CartDetails.Cart))]
        public virtual CartDetails IdCartDetailsNavigation { get; set; }
        [ForeignKey(nameof(IdProduct))]
        [InverseProperty(nameof(Product.Cart))]
        public virtual Product IdProductNavigation { get; set; }
    }
}
