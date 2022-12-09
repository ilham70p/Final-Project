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
    public class DriveTypeManager : IDriveTypeManager
    {
        private readonly IDriveTypeDal _driveTypeDal;

        public DriveTypeManager(IDriveTypeDal driveTypeDal)
        {
            _driveTypeDal = driveTypeDal;
        }

        public void AddDriveType(DrivingType driveType)
        {
            _driveTypeDal.Add(driveType);
        }

        public void DeleteDriveType(int id)
        {
            _driveTypeDal.Delete(_driveTypeDal.Get(id));
        }

        public List<DrivingType> GetAllDriveTypes()
        {
            return _driveTypeDal.GetAll();
        }

        public DrivingType GetDriveType(int id)
        {
            return _driveTypeDal.Get(id);
        }

        public void UpdateDriveType(DrivingType driveType, int Id)
        {
            _driveTypeDal.Update(driveType);
        }
    }
}
