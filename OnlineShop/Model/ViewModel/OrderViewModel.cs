﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class OrderViewModel
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ProductName { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public bool Status { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
