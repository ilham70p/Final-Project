using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IModelManager
    {
        List<CarModel> GetAll();
        CarModel GetById(int id);
        void AddModel(DtoCarModelCreate model);
        void UpdateModel(int Id,DtoCarModelCreate model);
        void DeleteModel(int Id);
    }
}
