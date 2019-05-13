using System;
using System.Collections.Generic;

namespace CigarShop.DataAccess.Entities
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Cigar = new HashSet<Cigar>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateModified { get; set; }
        public bool? Active { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Cigar> Cigar { get; set; }
    }
}
