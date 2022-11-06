using Core.DataAccess;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarImageDal:IRepository<CarImage>
    {
      
        string UploadImage(IFormFile file);
        void DeleteImageFromStorage(string fileName);
    }
}
