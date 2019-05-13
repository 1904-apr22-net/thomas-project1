using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CigarShop.Library.Models;

namespace CigarShop.DataAccess
{
    public static class Mapper
    {
        public static Library.Models.Manufacturer Map(Entities.Manufacturer manufacturer) => new Library.Models.Manufacturer
        {
            Id = manufacturer.Id,
            ManufacturerName = manufacturer.ManufacturerName,
            Cigars = Map(Manufacturer.Cigar).ToList()
        };

        public static Entities.Manufacturer Map(Library.Models.Manufacturer manufacturer) => new Entities.Manufacturer
        {
            Id = manufacturer.Id,
            ManufacturerName = manufacturer.ManufacturerName,
            Cigars = Map(Manufacturer.Cigar).ToList()
        };

        public static Library.Models.Manufacturer Map(Entities.Manufacturer manufacturer) => new Library.Models.Manufacturer
        {
            Id = manufacturer.Id,
            ManufacturerName = manufacturer.ManufacturerName,
            Cigars = Map(Manufacturer.Cigar).ToList()
        };


        public static IEnumerable<Library.Models.Cigar> Map(IEnumerable<Entities.Cigar> cigar) =>
            cigar.Select(Map);

        public static IEnumerable<Entities.Cigar> Map(IEnumerable<Library.Models.Cigar> cigar) =>
            cigar.Select(Map);

        public static IEnumerable<Library.Models.Manufacturer> Map(IEnumerable<Entities.Manufacturer> manufacturer) =>
            manufacturer.Select(Map);

        public static IEnumerable<Entities.Manufacturer> Map(IEnumerable<Library.Models.Manufacturer> manufacturer) =>
            manufacturer.Select(Map);
    }

}
