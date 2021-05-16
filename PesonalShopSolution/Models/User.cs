using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Model
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        [Column("id")]
        [StringLength(10)]
        public string Id { get; set; }
        [Column("User_name")]
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string Passwords { get; set; }
        public string Address { get; set; }
        [Column("Phone_number")]
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        [Column("Date_of_birth", TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        public string Status { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }

        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
