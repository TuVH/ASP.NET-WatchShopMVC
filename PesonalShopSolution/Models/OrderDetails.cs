using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Model
{
    [Table("Order_details")]
    public partial class OrderDetails
    {
        public OrderDetails()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        [Column("Id_Order_details")]
        [StringLength(10)]
        public string IdOrderDetails { get; set; }
        [Column("Into_money")]
        [StringLength(10)]
        public string IntoMoney { get; set; }
        public int? Amount { get; set; }
        [Column("Discount_code")]
        [StringLength(10)]
        public string DiscountCode { get; set; }
        [Column("Product_id")]
        [StringLength(10)]
        public string ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderDetails")]
        public virtual Product Product { get; set; }
        [InverseProperty("IdOrderDetailsNavigation")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
