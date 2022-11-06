using Core.DataAccess.EntityFramework;
using Core.Entity.Models;
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class AuthDal : Repository<UselessUser, AppDbContext>, IAuthDal
    {
       

       
        public UselessUser GetUserByEmail(string email)
        {
            using (AppDbContext context = new())
            {

                return context.Users.Where(a => a.Email == email).FirstOrDefault();

            }
        }
    }
}
