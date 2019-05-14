using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1_CigarShop.Models
{
    public class CigarViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; internal set; }
        [Required]
        [Display(Name = "Cigar Name")]
        public string Manufacturer { get; internal set; }

        [Display(Name = "Manufacturer's ID")]
        public int ManufacturerId { get; set; }
    }
}
