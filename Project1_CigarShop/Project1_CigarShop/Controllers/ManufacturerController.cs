using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CigarShop.Library.Interfaces;
using CigarShop.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project1_CigarShop.Controllers
{
    public class ManufacturerController : Controller
    {
        public ICigarRepository Repo { get; }

        public ManufacturerController(ICigarRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

/*
        public ActionResult Details(int id)
        {
            Manufacturer manufacturer = Repo.GetManufacturerById(id);
            var viewModel = new ManufacturerViewModel
            {
                Id = manufacturer.Id,
                Name = manufacturer.ManufacturerName,
                Cigars = manufacturer.Cigars.Select(y => new CigarViewModel
                {
                    Id = y.Id,
                    Manufacturer = y.CigarName,
                }),
            };
            return View(viewModel);
        }
        */
    }
}