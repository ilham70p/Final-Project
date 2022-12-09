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
    public class TransmissionManager : ITransmissionManager
    {
        private readonly ITransmissionDal _TransmissionDal;

        public TransmissionManager(ITransmissionDal TransmissionDal)
        {
            _TransmissionDal = TransmissionDal;
        }

        public void AddTransmission(Transmission Transmission)
        {
            _TransmissionDal.Add(Transmission);
        }

        public void DeleteTransmission(int id)
        {
            _TransmissionDal.Delete(_TransmissionDal.Get(id));
        }

        public List<Transmission> GetAllTransmissions()
        {
            return _TransmissionDal.GetAll();
        }

        public Transmission GetTransmission(int id)
        {
            return _TransmissionDal.Get(id);
        }

        public void UpdateTransmission(Transmission Transmission, int Id)
        {
            _TransmissionDal.Update(Transmission);
        }
    }
}
