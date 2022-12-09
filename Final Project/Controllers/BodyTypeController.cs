using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyTypeController : ControllerBase
    {
        private readonly IBodyTypeManager _manager;

        public BodyTypeController(IBodyTypeManager manager)
        {
            _manager = manager;
        }



        [HttpGet("getall")]
       public List<BodyType> GetAll()
        {
            return _manager.GetAllBodyTypes();
        }


        [HttpGet("Get")]
       public BodyType Get(int id)
        {
            return _manager.GetBodyType(id);
        }

        [HttpPost("add")]
        public void Add([FromForm] BodyType BodyType)
        {
            _manager.AddBodyType(BodyType);
        }

        [HttpPut("update")]
        public void Update([FromForm]int id,[FromForm]BodyType BodyType) {
            _manager.UpdateBodyType(BodyType, id);
        }

        [HttpDelete("delete")]
        public void Delete([FromForm]int id)
        {
            _manager.DeleteBodyType(id);
        }
    }
}
