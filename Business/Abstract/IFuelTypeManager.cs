using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFuelTypeManager
    {
        List<FuelType> GetAllFuelTypes();
        FuelType GetFuelType(int id); 
        void AddFuelType(FuelType fuelType);
        void UpdateFuelType(FuelType fuelType,int Id);
        void DeleteFuelType(int id);
    }
}
