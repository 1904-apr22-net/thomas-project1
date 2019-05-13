using CigarShop.DataAccess.Entities;
using CigarShop.Library.Interfaces;
using CigarShop.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cigar = CigarShop.DataAccess.Entities.Cigar;
using Manufacturer = CigarShop.DataAccess.Entities.Manufacturer;

namespace CigarShop.DataAccess.Repositories
{

    public class CigarRepository : ICigarRepository
    {
        private readonly Project0Context _dbContext;
        private readonly ILogger<CigarRepository> _logger;

       public CigarRepository(Project0Context dbContext, ILogger<CigarRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public IEnumerable<Library.Models.Cigar> GetCigar(string search = null)
        {
            IQueryable<Cigar> items = _dbContext.Cigar
                .Include(m => m.Manufacturer).AsNoTracking();
            if (search != null)
            {
                items = items.Where(m => m.Name.Contains(search));
            }
            return Mapper.Map(items);
        }
        public Library.Models.Cigar GetCigarById(int id)
        {
            Cigar cigar = _dbContext.Cigar.Include(m => m.Manufacturer)
                .AsNoTracking().First(m => m.Id == id);
            return Mapper.Map(cigar);
        }
        
        public void AddCigar(Library.Models.Cigar cigar)
        {
            if (cigar.Id != 0)
            {
                _logger.LogWarning("Cigar to be added has an ID ({cigarId}) already: ignoring.", cigar.Id);
            }

            _logger.LogInformation($"Adding cigar");

            Cigar entity = Mapper.Map(cigar);
            entity.Id = 0;
            _dbContext.Add(entity);
        }
        public void DeleteCigar(int cigarId)
        {
            _logger.LogInformation("Deleting cigar with ID {cigarId}", cigarId);
            Cigar entity = _dbContext.Cigar.Find(cigarId);
            _dbContext.Remove(entity);
        }
        public void UpdateCigar(Library.Models.Cigar cigar)
        {
            _logger.LogInformation("Updating cigar with ID {cigarId}", cigar.Id);

            Cigar currentEntity = _dbContext.Cigar.Find(cigar.Id);
            Cigar newEntity = Mapper.Map(cigar);

            _dbContext.Entry(currentEntity).CurrentValues.SetValues(newEntity);
        }
        public int CigarIdFromManufacturerId(int manufacturerId)
        {
            Manufacturer manufacturer = _dbContext.Manufacturer.AsNoTracking()
                .First(m => m.Id == manufacturerId);
            return int.Parse(manufacturer.Name);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose() => Dispose(true);

        public IEnumerable<Library.Models.Cigar> GetCigars(string search = null)
        {
            throw new NotImplementedException();
        }

        public Library.Models.Manufacturer GetManufacturerById(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
