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
    public class BodyTypeManager : IBodyTypeManager
    {
        private readonly IBodyTypeDal _bodyTypeDal;

        public BodyTypeManager(IBodyTypeDal bodyTypeDal)
        {
            _bodyTypeDal = bodyTypeDal;
        }

        public void AddBodyType(BodyType bodyType)
        {
            _bodyTypeDal.Add(bodyType);
        }

        public void DeleteBodyType(int id)
        {
            _bodyTypeDal.Delete(_bodyTypeDal.Get(id));
        }

        public List<BodyType> GetAllBodyTypes()
        {
            return _bodyTypeDal.GetAll();
        }

        public BodyType GetBodyType(int id)
        {
            return _bodyTypeDal.Get(id);
        }

        public void UpdateBodyType(BodyType bodyType, int Id)
        {
            _bodyTypeDal.Update(bodyType);
        }
    }
}
