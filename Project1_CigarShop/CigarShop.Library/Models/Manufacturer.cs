using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Models
{
    public class Manufacturer
    {
        private string _manufacturerName;
        public int Id { get; set; }

        public string CigarName { get; set; }

        public List<Cigar> Cigars { get; set; } = new List<Cigar>();

        public int CigarId { get; set; }
        public string ManufacturerName { get => _manufacturerName; set => _manufacturerName = value; }
    }
}
