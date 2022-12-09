using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDriveTypeManager
    {
        List<DrivingType> GetAllDriveTypes();
        DrivingType GetDriveType(int id); 
        void AddDriveType(DrivingType driveType);
        void UpdateDriveType(DrivingType driveType,int Id);
        void DeleteDriveType(int id);
    }
}
