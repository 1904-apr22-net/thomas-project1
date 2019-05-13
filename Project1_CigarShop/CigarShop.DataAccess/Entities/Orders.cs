using System;
using System.Collections.Generic;

namespace CigarShop.DataAccess.Entities
{
    public partial class Orders
    {
        public int Id { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime DatePlaced { get; set; }
        public DateTime DateModified { get; set; }
        public bool? Active { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
