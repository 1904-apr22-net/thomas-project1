using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CigarShop.DataAccess.Entities;
using CigarShop.Library.Interfaces;
using CigarShop.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Project1_CigarShop.Models;
using Manufacturer = CigarShop.Library.Models.Manufacturer;

namespace Project1_CigarShop.Controllers
{
    public class ManufacturerController : Controller
    {
        public ICigarRepository Repo { get; }

        public ManufacturerController(ICigarRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        public ActionResult Index([FromQuery] string search = "")
        {
            IEnumerable<CigarShop.Library.Models.Manufacturer> manufacturers = Repo.GetManufacturers(search);
            IEnumerable<ManufacturerViewModel> viewModels = manufacturers.Select(x => new ManufacturerViewModel
            {
                Id = x.Id,
                Name = x.CigarName,
                Cigars = x.Cigars.Select(y => new CigarViewModel())
            });
            return View(viewModels);
        }
        public ActionResult Details(int id)
        {
            CigarShop.Library.Models.Manufacturer manufacturer = Repo.GetManufacturerById(id);
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

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name")]ManufacturerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var manufacturer = new Manufacturer
                    {
                        ManufacturerName = viewModel.Name
                    };
                    Repo.AddManufacturer(manufacturer);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View();
            }
        }

        

    }
}