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
    public class FuelTypeController : ControllerBase
    {
        private readonly IFuelTypeManager _manager;

        public FuelTypeController(IFuelTypeManager manager)
        {
            _manager = manager;
        }



        [HttpGet("getall")]
       public List<FuelType> GetAll()
        {
            return _manager.GetAllFuelTypes();
        }


        [HttpGet("Get")]
       public FuelType Get(int id)
        {
            return _manager.GetFuelType(id);
        }

        [HttpPost("add")]
        public void Add([FromForm] FuelType FuelType)
        {
            _manager.AddFuelType(FuelType);
        }

        [HttpPut("update")]
        public void Update([FromForm]int id,[FromForm]FuelType FuelType) {
            _manager.UpdateFuelType(FuelType, id);
        }

        [HttpDelete("delete")]
        public void Delete([FromForm]int id)
        {
            _manager.DeleteFuelType(id);
        }
    }
}
