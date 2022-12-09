using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBodyTypeManager
    {
        List<BodyType> GetAllBodyTypes();
        BodyType GetBodyType(int id); 
        void AddBodyType(BodyType bodyType);
        void UpdateBodyType(BodyType bodyType,int Id);
        void DeleteBodyType(int id);
    }
}
