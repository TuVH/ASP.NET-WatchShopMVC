﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesonalShopSolution.ViewModels
{
    public class CreateOrder
    {
        public DateTime? OrderDate { get; set; }
        public int IdUser { get; set; }
        public int TotalMoney { get; set; }
    }
}
