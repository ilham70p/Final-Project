﻿using Core.DataAccess.EntityFramework;
using Core.Entity.Models;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class RoleDal:Repository<Role, AppDbContext>, IRoleDal
    {
        public Role GetUserRole(int userId)
        {
            using AppDbContext context = new();

            var roleUser = context.UserRoles.Include(x=>x.Role).FirstOrDefault(x=>x.UserId == userId);

            var role = new Role()
            {
                Id = roleUser.RoleId,
                Name = roleUser.Role.Name
            };

            return role;
        }
    }
}
