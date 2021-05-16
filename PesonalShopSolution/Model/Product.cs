using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Model
{
    public partial class Product
    {
        public Product()
        {
            Cart = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        [Column("ID_Product")]
        [StringLength(10)]
        public string IdProduct { get; set; }
        [Column("Product_name")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(10)]
        public string Price { get; set; }
        [Column("Detailed_description")]
        public string DetailedDescription { get; set; }
        [Column("Specifications_id")]
        [StringLength(10)]
        public string SpecificationsId { get; set; }
        [Column("Trademark_id")]
        [StringLength(10)]
        public string TrademarkId { get; set; }
        [StringLength(10)]
        public string Evaluate { get; set; }
        public string Comments { get; set; }
        [Column("Delivery_and_returns")]
        public string DeliveryAndReturns { get; set; }
        public string Finance { get; set; }

        [ForeignKey(nameof(SpecificationsId))]
        [InverseProperty("Product")]
        public virtual Specifications Specifications { get; set; }
        [ForeignKey(nameof(TrademarkId))]
        [InverseProperty("Product")]
        public virtual Trademark Trademark { get; set; }
        [InverseProperty("IdProductNavigation")]
        public virtual ICollection<Cart> Cart { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
