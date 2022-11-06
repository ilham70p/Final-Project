using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceManager
    {
        List<Service> GetAllServices();
        Service GetServiceById(int Id);
        void AddService(Service service);
        void UpdateService(Service brand, int Id);
        void DeleteService(int Id);
    }
}
