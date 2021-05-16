using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Model
{
    [Table("Cart_details")]
    public partial class CartDetails
    {
        public CartDetails()
        {
            Cart = new HashSet<Cart>();
        }

        [Key]
        [Column("id")]
        [StringLength(10)]
        public string Id { get; set; }
        [Column("Into_money")]
        public int? IntoMoney { get; set; }
        [Column("id_product")]
        [StringLength(10)]
        public string IdProduct { get; set; }

        [InverseProperty("IdCartDetailsNavigation")]
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
