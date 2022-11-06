using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDealerManager
    {
        List<Dealer> GetAllDealers();
        Dealer GetDealerById(int id);
        void AddDealer(DtoDealerCreate dealer);
        void UpdateDealer(DtoDealerCreate dealer,int Id);
        void DeleteDealer(int id);
    }
}
