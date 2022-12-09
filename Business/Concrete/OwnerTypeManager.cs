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
    public class OwnerTypeManager : IOwnerTypeManager
    {
        private readonly IOwnerTypeDal _OwnerTypeDal;

        public OwnerTypeManager(IOwnerTypeDal OwnerTypeDal)
        {
            _OwnerTypeDal = OwnerTypeDal;
        }

        public void AddOwnerType(OwnerType OwnerType)
        {
            _OwnerTypeDal.Add(OwnerType);
        }

        public void DeleteOwnerType(int id)
        {
            _OwnerTypeDal.Delete(_OwnerTypeDal.Get(id));
        }

        public List<OwnerType> GetAllOwnerTypes()
        {
            return _OwnerTypeDal.GetAll();
        }

        public OwnerType GetOwnerType(int id)
        {
            return _OwnerTypeDal.Get(id);
        }

        public void UpdateOwnerType(OwnerType OwnerType, int Id)
        {
            _OwnerTypeDal.Update(OwnerType);
        }
    }
}
