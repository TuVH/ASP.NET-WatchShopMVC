using System;
using System.Collections.Generic;

namespace PesonalShopSolution.Models
{
    public partial class BillDetails
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}
