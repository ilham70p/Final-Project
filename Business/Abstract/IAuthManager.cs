using Core.Entity.Models;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthManager
    {
        void Register(DtoRegister model);
        UselessUser GetUserByEmail(string email);
        UselessUser Login(string email);
        List<UselessUser> GetUsers();
    }
}
