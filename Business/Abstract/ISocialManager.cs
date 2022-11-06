using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISocialManager
    {
        List<Social> GetAll();
        Social GetSocial(int id);
        public void Add(Social social);
        public void Update(Social social,int Id);
        public void Delete(int Id);
    }
}
