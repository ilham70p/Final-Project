using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager:IBrandManager
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void AddBrand(DtoBrandCreate brand)
        {
            string imageName  = _brandDal.UploadImage(brand.Image);
            string imageBase = _brandDal.ConvertImage(imageName);
            Brand mybrand = new Brand { Name=brand.Name,ImageFile=brand.Image,ImageName=imageName,Base64Image=imageBase  };
            _brandDal.Add(mybrand);
        }

        public void DeleteBrand(int Id)
        {
            Brand mybrand = _brandDal.Get(Id);
            _brandDal.DeleteImage(mybrand.ImageName);
            _brandDal.Delete(mybrand);

        }

        public List<Brand> GetAllBrand()
        {
           return _brandDal.GetAll();
        }

        public Brand GetBrandById(int Id)
        {
            return _brandDal.Get(Id);
        }

        public void UpdateBrand(DtoBrandCreate brand, int Id)
        {
            Brand mybrand = _brandDal.Get(Id);
            _brandDal.DeleteImage(mybrand.ImageName);
            string imageName = _brandDal.UploadImage(brand.Image);
            mybrand.ImageName = imageName;
            mybrand.ImageFile = brand.Image;
            mybrand.Name = brand.Name;
            _brandDal.Update(mybrand);
        }
    }
}
