using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SocialManager : ISocialManager
    {
        private readonly ISocialDal _socialDal;

        public SocialManager(ISocialDal socialDal)
        {
            _socialDal = socialDal;
        }
    
        public void Add(Social social)
        {
            _socialDal.Add(social);
        }
       
        public void Delete(int Id)
        {

            _socialDal.Delete(_socialDal.Get(Id));
        }
      
        public List<Social> GetAll()
        {
            return _socialDal.GetAll();
        }
        public Social GetSocial(int id)
        {
           return _socialDal.Get(id);
        }
        public void Update(Social social,int Id)
        {
            Social mysocial = _socialDal.Get(Id);
            mysocial.Name = social.Name;
            mysocial.IconName = social.IconName;
            _socialDal.Update(mysocial);
        }
    }
}
