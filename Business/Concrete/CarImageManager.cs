using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarImageManager(ICarImageDal imageDal, IWebHostEnvironment webHostEnvironment)
        {
            _imageDal = imageDal;
            _webHostEnvironment = webHostEnvironment;
        }

        public void AddCarImage(IFormFile carImage,int CarId)
        {
            string imageName =  _imageDal.UploadImage(carImage);
            string imageBase = ConvertImage(imageName);  
            CarImage myimage = new CarImage {ImageName=imageName,CarId=CarId,Base64Image=imageBase  };
            _imageDal.Add(myimage);          
        }

        public void DeleteImage(int Id)
        {
            CarImage myimage=  _imageDal.Get(Id);
            _imageDal.DeleteImageFromStorage(myimage.ImageName);
            _imageDal.Delete(myimage);
        }
        public string ConvertImage(string fileName)
        {
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
            byte[] b = System.IO.File.ReadAllBytes(filePath);
            return Convert.ToBase64String(b);
        }
    }
}
