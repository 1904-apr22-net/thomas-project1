using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Models
{
    public class Store
    {
        private int _storeId;
        public int StoreId;
        //public int[] Invintory { get; set; } = new int[int[10], int[2]];
        public string StoreLocation { get; set; }
        public int CigarId { get; set; }
        protected int initialInvintory = 60;

        public int[] invintory = new int[20];

        foreach (row in cigar.cigar)
        invintory[CigarId] = initialInvintory;

    }
}
