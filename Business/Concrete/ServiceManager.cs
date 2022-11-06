using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void AddService([FromForm]Service service)
        {
            string imageName = _serviceDal.UploadImage(service.ImageFile);
            Service mybrand = new Service { Title= service.Title,Description=service.Description, ImageFile = service.ImageFile, ImageName = imageName };
            _serviceDal.Add(mybrand);
        }

        public void DeleteService(int Id)
        {
            Service myservice = _serviceDal.Get(Id);
            _serviceDal.DeleteImage(myservice.ImageName);
            _serviceDal.Delete(myservice);
        }
    
        public List<Service> GetAllServices()
        {
            return _serviceDal.GetAll();
        }
 
        public Service GetServiceById(int Id)
        {
           return _serviceDal.Get(Id);
        }
   
        public void UpdateService(Service service, int Id)
        {
            Service myservice = _serviceDal.Get(Id);
            _serviceDal.DeleteImage(myservice.ImageName);
            string imageName = _serviceDal.UploadImage(service.ImageFile);
            myservice.ImageName = imageName;
            myservice.ImageFile = myservice.ImageFile;
            myservice.Title = service.Title;
            myservice.Description = service.Description;
            _serviceDal.Update(myservice);
        }
    }
}
