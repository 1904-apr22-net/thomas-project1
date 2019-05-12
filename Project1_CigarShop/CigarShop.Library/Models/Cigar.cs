using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Models
{
    public class Cigar
    {
        private string _cigarname;
        public int Id { get; set; }

        public string cigarName
        {
            get => _cigarname;
            set
            {
                if (value.Length == 0)
                {
                     throw new ArgumentException("Cigar Name must not be empty.", nameof(value));
                 }
             _cigarname = value;
            }
        }
    }
}
