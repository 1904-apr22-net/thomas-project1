﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CigarShop.Library.Models;

namespace CigarShop.DataAccess
{
    public static class Mapper
    {
        public static Library.Models.Cigar Map(Entities.Cigar cigar) => new Library.Models.Cigar
        {
            Id = cigar.Id,
            cigarName = cigar.CigarName,
            Cigar = Map(Manufacturer.ManufacturerName).ToList()
        };

        public static Entities.Cigar Map(Library.Models.Cigar cigar) => new Entities.Cigar
        {
            Id = cigar.Id,
            Name = cigar.cigarName,
            Cigar = Map(Manufacturer.ManufacturerName).ToList()
        };

        public static Library.Models.Manufacturer Map(Entities.Manufacturer manufacturer) => new Library.Models.Manufacturer
        {
            Id = manufacturer.Id,
            ManufacturerName = manufacturer.ManufacturerName,
            Cigar = Map(Manufacturer.ManufacturerName).ToList()
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
