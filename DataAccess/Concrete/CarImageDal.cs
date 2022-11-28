using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CarImageDal : Repository<CarImage, AppDbContext>, ICarImageDal
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarImageDal(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;           
        }

        public void DeleteImageFromStorage(string fileName)
        {
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        public string UploadImage(IFormFile file)
        {
            string fileName = Guid.NewGuid() + "-" + file.FileName;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;

        }

    }
}