using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project1_CigarShop.Controllers
{
    public class CigarController : Controller
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cigar Name")]
        public string CigarName { get; set; }

        [Required]
        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; }

        [Required]
        [Display(Name = "Body Characteristic")]
        public string BodyChar { get; set; }

        [Display(Name = "Manufacturer ID")]
        public int RestaurantId { get; set; }       


    }
}