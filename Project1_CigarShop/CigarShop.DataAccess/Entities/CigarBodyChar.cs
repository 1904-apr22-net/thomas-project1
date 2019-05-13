using System;
using System.Collections.Generic;

namespace CigarShop.DataAccess.Entities
{
    public partial class CigarBodyChar
    {
        public CigarBodyChar()
        {
            Cigar = new HashSet<Cigar>();
        }

        public int Id { get; set; }
        public string Body { get; set; }

        public virtual ICollection<Cigar> Cigar { get; set; }
    }
}
