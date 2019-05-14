﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Models
{
    public class Order
    {
        private int _orderId;
        public int OrderId { get; set; }

        public List<Cigar> Cigars { get; set; } = new List<Cigar>();
        public int Price { get; set; }
        public int StoreId { get; set; }
        public int CusomerId { get; set; } 
    }
}
