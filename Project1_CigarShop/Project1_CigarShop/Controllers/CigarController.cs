using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CigarShop.Library.Models;
using CigarShop.Library.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Project1_CigarShop.Controllers
{
    public class CigarController : Controller
    {
        public ICigarRepository Repo { get; }
        public CigarController(ICigarRepository repo) => Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        public ActionResult Details(int id)
        {
            Cigar cigar = Repo.GetCigarById(id);
            var manufacturerId = Repo.ManufacturerIdFromCigarId(id);
            var viewModel = new CigarModel
            {
                Id = cigar.Id,
                CigarName = cigar.CigarName,
                ManufacturerId = manufacturerId

            };
            return View(viewModel);
        }
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