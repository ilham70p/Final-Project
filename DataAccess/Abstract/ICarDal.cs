using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IRepository<Car>
    {

        List<DtoCar> GetAllCar();
        DtoCar GetCar(int id);
        public List<Car> Filter(string? q, decimal? minPrice, decimal? maxPrice, int? sortBy, int? brandId, bool? condition, int? bodyTypeId, DateTime? year, int? transmissionId, int? driveTypeId, int? minMilage, int? maxMilage, int? ownerTypeId, bool? sellerType, int? offerTypeId);
    }
}
