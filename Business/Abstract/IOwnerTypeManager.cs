using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOwnerTypeManager
    {
        List<OwnerType> GetAllOwnerTypes();
        OwnerType GetOwnerType(int id); 
        void AddOwnerType(OwnerType ownerType);
        void UpdateOwnerType(OwnerType ownerType,int Id);
        void DeleteOwnerType(int id);
    }
}
