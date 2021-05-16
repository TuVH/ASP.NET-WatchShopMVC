using System;
using System.Collections.Generic;

namespace PesonalShopSolution.Models
{
    public partial class Bill
    {
        public Bill()
        {
            BillDetails = new HashSet<BillDetails>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string Phone { get; set; }
        public bool Approve { get; set; }

        public virtual ICollection<BillDetails> BillDetails { get; set; }
    }
}
