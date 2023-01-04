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
    public class DriveTypeController : ControllerBase
    {
        private readonly IDriveTypeManager _manager;

        public DriveTypeController(IDriveTypeManager manager)
        {
            _manager = manager;
        }



        [HttpGet("getall")]
       public List<DrivingType> GetAll()
        {
            return _manager.GetAllDriveTypes();
        }


        [HttpGet("get")]
       public DrivingType Get(int id)
        {
            return _manager.GetDriveType(id);
        }

        [HttpPost("add")]
        public void Add([FromForm] DrivingType DriveType)
        {
            _manager.AddDriveType(DriveType);
        }

        [HttpPut("update")]
        public void Update([FromForm]int id,[FromForm]DrivingType DriveType) {
            _manager.UpdateDriveType(DriveType, id);
        }

        [HttpDelete("delete")]
        public void Delete([FromForm]int id)
        {
            _manager.DeleteDriveType(id);
        }
    }
}
