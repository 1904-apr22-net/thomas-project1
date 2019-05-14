using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1_CigarShop.Models
{
    public class ManufacturerViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; internal set; }

        [Required]
        public string Name { get; internal set; }

        public IEnumerable<CigarViewModel> Cigars { get; internal set; }
    }
}
