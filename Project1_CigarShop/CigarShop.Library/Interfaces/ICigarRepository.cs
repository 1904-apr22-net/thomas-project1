using CigarShop.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Interfaces
{
    public interface ICigarRepository
    {
        IEnumerable<Cigar> GetCigars(string search = null);

        Cigar GetCigarById(int id);

        void AddCigar(Cigar cigar);

        void DeleteCigar(int cigarId);

        void UpdateCigar(Cigar cigar);



        
    }
}
