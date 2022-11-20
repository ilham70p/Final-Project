    using Business.Abstract;
using Core.Entity.Models;
using Core.Security.Hashing;
using Core.Security.TokenHandler;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly TokenGenerator _tokenGenerator;
        private readonly HashingHandler _hashingHandler;


        public AuthController(IAuthManager authManager, TokenGenerator tokenGenerator, HashingHandler hashingHandler)
        {
            _authManager = authManager;
            _tokenGenerator = tokenGenerator;
            _hashingHandler = hashingHandler;
  
        }

        [HttpPost("login")]
        public async Task<object> LoginUser([FromForm]DtoLogin model)
        {
            var user = _authManager.Login(model.Email);
            if (user == null) return Ok(new { status = 404, message = "Bele bir istifadeci tapilmadi." });

            if (user.Email == model.Email && user.Password == _hashingHandler.PasswordHash(model.Password))
            {

                
                var resultUser = new DtoUser(user.Id, user.FullName, user.Email);
                resultUser.Token = _tokenGenerator.Token(user);

                return Ok(new { status = 200, message = resultUser });
            }

            return Ok(new { status = 404, message = "Email ve ya sifre sehfdi." });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm]DtoRegister model)
        {
            var user = _authManager.GetUserByEmail(model.Email);

            if (user != null)
            {
                return Ok(new { status = 201, message = "Email is exist." });
            }
            _authManager.Register(model);

            return Ok(new { status = 200, message = "Okey" });
        }

        [Authorize]
        [HttpGet("getbyemail")]
        public async Task<object> GetByEmail()
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var email = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "email").Value;

            var user = _authManager.GetUserByEmail(email);
            var result = new DtoUser(user.Id, user.FullName, user.Email);
            return Ok(result);
        }


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        [HttpGet("allusers")]
        public List<UselessUser> GetUsers()
        {
            return _authManager.GetUsers();
        }

    }
}
