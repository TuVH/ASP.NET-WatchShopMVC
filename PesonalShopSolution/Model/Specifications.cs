using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PesonalShopSolution.Model
{
    public partial class Specifications
    {
        public Specifications()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        [Column("Id_specifications")]
        [StringLength(10)]
        public string IdSpecifications { get; set; }
        [Column("Trademark_id")]
        [StringLength(10)]
        public string TrademarkId { get; set; }
        [Column("Case_depth_approx")]
        [StringLength(20)]
        public string CaseDepthApprox { get; set; }
        [Column("Case_Shape")]
        [StringLength(10)]
        public string CaseShape { get; set; }
        [Column("Clasp_type")]
        [StringLength(20)]
        public string ClaspType { get; set; }
        public bool? Gender { get; set; }
        [Column("Movement_Calibre")]
        [StringLength(10)]
        public string MovementCalibre { get; set; }
        [Column("Strap_colour")]
        [StringLength(10)]
        public string StrapColour { get; set; }
        [Column("Primary_Material")]
        [StringLength(50)]
        public string PrimaryMaterial { get; set; }
        [Column("Strap_Type")]
        [StringLength(10)]
        public string StrapType { get; set; }
        [StringLength(10)]
        public string Weight { get; set; }
        [StringLength(10)]
        public string Guarantee { get; set; }

        [ForeignKey(nameof(TrademarkId))]
        [InverseProperty("Specifications")]
        public virtual Trademark Trademark { get; set; }
        [InverseProperty("Specifications")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
