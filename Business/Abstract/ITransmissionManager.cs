using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITransmissionManager
    {
        List<Transmission> GetAllTransmissions();
        Transmission GetTransmission(int id); 
        void AddTransmission(Transmission transmission);
        void UpdateTransmission(Transmission ransmission, int Id);
        void DeleteTransmission(int id);
    }
}
