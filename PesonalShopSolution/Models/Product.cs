using System;
using System.Collections.Generic;

namespace PesonalShopSolution.Models
{
    public partial class Product
    {
        public Product()
        {
            BillDetails = new HashSet<BillDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int? IdCategory { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual ICollection<BillDetails> BillDetails { get; set; }
    }
}
