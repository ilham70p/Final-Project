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
    public class CarController : ControllerBase
    {
        private readonly ICarManager _manager;

        public CarController(ICarManager manager)
        {
            _manager = manager;
        }

        [HttpGet("getall")]
       public List<DtoCar> GetAll() {
            var cars = _manager.GetAllCars();

            return cars;

        }

        [HttpGet("get")]
        public DtoCar Get(int id) {
        
             return  _manager.GetCarById(id);
        
        }
        [HttpGet("getbypage")]
        public List<DtoCar> GetCarsByPage([FromQuery]int page, [FromQuery] int pageSize)
        {
            return _manager.GetCarsByPage(page, pageSize);
        }

        [HttpPost("post")]
        public void Post([FromForm]DtoCarCreate car) {

            _manager.AddCar(car);
        
        }

        [HttpPut("update")]
        public void Update([FromForm]int id,[FromForm] DtoCarCreate car) {


            _manager.UpdateCar(id, car);
        
        
        }
        [HttpDelete("delete")]
        public void Delete([FromForm] int Id) { 
        
        _manager.DeleteCar(Id);
        }
    }
}
