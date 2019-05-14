using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CigarShop.DataAccess.Entities;
using CigarShop.Library.Interfaces;
using CigarShop.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Project1_CigarShop.Models;

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
            IEnumerable<ManufacturerViewModel> viewModels = manufacturers.Select(x => ManufacturerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CigarShop.Library.Models.Cigar = x.Cigars.Select(y => new CigarViewModel())
            });
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
        
    }
}