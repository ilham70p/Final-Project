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
    public class OfferTypeManager : IOfferTypeManager
    {
        private readonly IOfferTypeDal _OfferTypeDal;

        public OfferTypeManager(IOfferTypeDal OfferTypeDal)
        {
            _OfferTypeDal = OfferTypeDal;
        }

        public void AddOfferType(OfferType OfferType)
        {
            _OfferTypeDal.Add(OfferType);
        }

        public void DeleteOfferType(int id)
        {
            _OfferTypeDal.Delete(_OfferTypeDal.Get(id));
        }

        public List<OfferType> GetAllOfferTypes()
        {
            return _OfferTypeDal.GetAll();
        }

        public OfferType GetOfferType(int id)
        {
            return _OfferTypeDal.Get(id);
        }

        public void UpdateOfferType(OfferType OfferType, int Id)
        {
            _OfferTypeDal.Update(OfferType);
        }
    }
}
