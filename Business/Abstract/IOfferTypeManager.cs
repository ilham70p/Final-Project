using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOfferTypeManager
    {
        List<OfferType> GetAllOfferTypes();
        OfferType GetOfferType(int id); 
        void AddOfferType(OfferType offerType);
        void UpdateOfferType(OfferType offerType,int Id);
        void DeleteOfferType(int id);
    }
}
