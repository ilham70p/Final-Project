using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialController : ControllerBase
    {
        private readonly ISocialManager _manager;

        public SocialController(ISocialManager manager)
        {
            _manager = manager;
        }
        [HttpGet("getall")]
        public List<Social> GetAll() {

           return _manager.GetAll();

        }

        [HttpGet("get")]
       public Social Get([FromForm]int id) {

            return _manager.GetSocial(id);
        }


        [HttpPost("post")]
        public void Post([FromForm]Social social) {

            _manager.Add(social);
        
        }

        [HttpPut("update")]
        public void Put([FromForm] Social social,int Id) {
        
            _manager.Update(social, Id);
        
        }
        

        [HttpDelete("delete")]
        public void Delete([FromForm]int Id) {

            _manager.Delete(Id);
        
        }
    }
}
