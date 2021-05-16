using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Model
{
    public partial class Order
    {
        [Key]
        [Column("id")]
        [StringLength(10)]
        public string Id { get; set; }
        [Column("Id_user")]
        [StringLength(10)]
        public string IdUser { get; set; }
        [Column("order_date", TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [Column("id_order_details")]
        [StringLength(10)]
        public string IdOrderDetails { get; set; }

        [ForeignKey(nameof(IdOrderDetails))]
        [InverseProperty(nameof(OrderDetails.Order))]
        public virtual OrderDetails IdOrderDetailsNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.Order))]
        public virtual User IdUserNavigation { get; set; }
    }
}
