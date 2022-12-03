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
        List<DtoCar> GetAllCars();
        DtoCar GetCarById(int Id);
        void AddCar(DtoCarCreate car);
        void UpdateCar(int Id, DtoCarCreate car);
        void DeleteCar(int Id);
        List<DtoCar> GetCarsByPage(int pageNumber, int pageSize);
    }
}
