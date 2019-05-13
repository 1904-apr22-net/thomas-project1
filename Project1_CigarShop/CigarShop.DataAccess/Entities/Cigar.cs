using System;
using System.Collections.Generic;

namespace CigarShop.DataAccess.Entities
{
    public partial class Cigar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateModified { get; set; }
        public bool? Active { get; set; }
        public int ManufacturerId { get; set; }
        public int BodyId { get; set; }

        public virtual CigarBodyChar Body { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
