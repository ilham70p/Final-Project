using Business.Abstract;
using Core.Entity.Models;
using Core.Security.Hashing;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthManager
    {
        private readonly IAuthDal _authDal;
        private readonly HashingHandler _hashingHandler;
        private readonly IUserRoleManager _userRoleManager;

        public AuthManager(IAuthDal authDal, HashingHandler hashingHandler, IUserRoleManager userRoleManager)
        {
            _authDal = authDal;
            _hashingHandler = hashingHandler;
            _userRoleManager = userRoleManager;
        }

        public UselessUser GetUserByEmail(string email)
        {
           return _authDal.GetUserByEmail(email);
        }

        public List<UselessUser> GetUsers()
        {
            throw new NotImplementedException();
        }

        public UselessUser Login(string email)
        {
            UselessUser user = _authDal.GetUserByEmail(email);
            if (user == null)
            {
                return null;
            }
            else {

                return user;
            
            }
        }

        public void Register(DtoRegister model)
        {
            UselessUser user = new()
            {
                Email = model.Email,
                FullName = model.FullName,
                Password = _hashingHandler.PasswordHash(model.Password),
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
            };
            _authDal.Add(user);
            var currentUser = _authDal.GetUserByEmail(user.Email);
            _userRoleManager.AddDefaultRole(currentUser.Id);
        }
    }
}
