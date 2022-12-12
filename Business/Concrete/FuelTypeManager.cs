using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FuelTypeManager : IFuelTypeManager
    {
        private readonly IFuelTypeDal _FuelTypeDal;

        public FuelTypeManager(IFuelTypeDal FuelTypeDal)
        {
            _FuelTypeDal = FuelTypeDal;
        }

        public void AddFuelType(FuelType FuelType)
        {
            _FuelTypeDal.Add(FuelType);
        }

        public void DeleteFuelType(int id)
        {
            _FuelTypeDal.Delete(_FuelTypeDal.Get(id));
        }

        public List<FuelType> GetAllFuelTypes()
        {
            return _FuelTypeDal.GetAll();
        }

        public FuelType GetFuelType(int id)
        {
            return _FuelTypeDal.Get(id);
        }

        public void UpdateFuelType(FuelType FuelType, int Id)
        {
            _FuelTypeDal.Update(FuelType);
        }
    }
}
