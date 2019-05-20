using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CigarShop.Library.Models;
using CigarShop.Library.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Project1_CigarShop.Models;

namespace Project1_CigarShop.Controllers
{
    public class CigarController : Controller
    {
        public ICigarRepository Repo { get; }
        public CigarController(ICigarRepository repo) => 
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        public ActionResult Details(int id)
        {
            Cigar cigar = Repo.GetCigarById(id);
            var manufacturerId = Repo.ManufacturerIdFromCigarId(id);
            var viewModel = new CigarViewModel
            {
                Id = cigar.Id,
                CigarName = cigar.CigarName,
                ManufacturerId = manufacturerId
            };
            return View(viewModel);
        }
         


    }
}