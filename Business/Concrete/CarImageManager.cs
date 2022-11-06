using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageManager
    {
        private readonly ICarImageDal _imageDal;

        public CarImageManager(ICarImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public void AddCarImage(IFormFile carImage,int CarId)
        {
          string imageName =  _imageDal.UploadImage(carImage);
          CarImage myimage = new CarImage {ImageName=imageName,CarId=CarId };
          _imageDal.Add(myimage);          
        }

        public void DeleteImage(int Id)
        {
           CarImage myimage=  _imageDal.Get(Id);
            _imageDal.DeleteImageFromStorage(myimage.ImageName);
            _imageDal.Delete(myimage);
        }
    }
}
