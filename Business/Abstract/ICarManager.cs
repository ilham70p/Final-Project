using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarManager
    {
        List<Car> GetAllCars();
        Car GetCarById(int Id);
        void AddCar(DtoCarCreate car);
        void UpdateCar(int Id, DtoCarCreate car);
        void DeleteCar(int Id);
        List<Car> GetCarsByPage(int pageNumber, int pageSize);
    }
}
