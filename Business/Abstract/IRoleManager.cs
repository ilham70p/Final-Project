using Core.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleManager
    {
        Role GetUserRole(int userId);
        Role GetRole(int roleId);
        public void AddRole(Role role);
    }
}
