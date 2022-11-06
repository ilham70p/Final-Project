using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandManager
    {
        List<Brand> GetAllBrand();
        Brand GetBrandById(int Id);
        void AddBrand(DtoBrandCreate brand);
        void UpdateBrand(DtoBrandCreate brand,int Id);
        void DeleteBrand(int Id);
    }
}
