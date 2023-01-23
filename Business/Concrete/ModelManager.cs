using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ModelManager : IModelManager
    {
        private readonly IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public void AddModel([FromForm]DtoCarModelCreate model)
        {
            CarModel carmodel = new CarModel {Name=model.Name,BrandId=model.BrandId, FeatureId=model.FeatureId };
            _modelDal.Add(carmodel);
        }
      
        public void DeleteModel(int Id)
        {
            _modelDal.Delete(_modelDal.Get(Id));
        }
   
        public List<CarModel> GetAll()
        {
          return _modelDal.GetAll();
        }
    
        public CarModel GetById(int id)
        {
          return  _modelDal.Get(id);
        }
   
        public void UpdateModel( int Id,DtoCarModelCreate model)
        {
           CarModel mymodel = _modelDal.Get(Id);
           mymodel.BrandId = model.BrandId;
          mymodel.Name = model.Name;
            _modelDal.Update(mymodel);
        }
    }
}
