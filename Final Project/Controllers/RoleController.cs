using Business.Abstract;
using Core.Entity.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleManager _roleManager;
        private readonly IUserRoleManager _userRoleManager;

        public RoleController(IRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet("getrole")]
        public Role Get([FromQuery]int id)
        {
            return _roleManager.GetRole(id);
        }

        [HttpPost("addrole")]
        public void Add([FromForm] Role role)
        {
            _roleManager.AddRole(role);
        }
        [HttpPost("assignrole")]
        public void AssignRole(int userId, int roleId)
        {
            _userRoleManager.AssignRole(userId, roleId);
        }
    }
}
