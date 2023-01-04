using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageManager
    {
        void AddCarImage(DtoCarImage carImage,int CarId);
        void DeleteImage(int Id);

    }
}
