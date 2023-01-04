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
    public class OwnerTypeController : ControllerBase
    {
        private readonly IOwnerTypeManager _manager;

        public OwnerTypeController(IOwnerTypeManager manager)
        {
            _manager = manager;
        }



        [HttpGet("getall")]
       public List<OwnerType> GetAll()
        {
            return _manager.GetAllOwnerTypes();
        }


        [HttpGet("get")]
       public OwnerType Get(int id)
        {
            return _manager.GetOwnerType(id);
        }

        [HttpPost("add")]
        public void Add([FromForm] OwnerType OwnerType)
        {
            _manager.AddOwnerType(OwnerType);
        }

        [HttpPut("update")]
        public void Update([FromForm]int id,[FromForm]OwnerType OwnerType) {
            _manager.UpdateOwnerType(OwnerType, id);
        }

        [HttpDelete("delete")]
        public void Delete([FromForm]int id)
        {
            _manager.DeleteOwnerType(id);
        }
    }
}
