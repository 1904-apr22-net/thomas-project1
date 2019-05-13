using System;
using System.Collections.Generic;

namespace CigarShop.DataAccess.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string DefaultStore { get; set; }
        public DateTime DateModified { get; set; }
        public bool? Active { get; set; }
        public int DefaultStoreId { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
