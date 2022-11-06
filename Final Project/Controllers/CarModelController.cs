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
    public class CarModelController : ControllerBase
    {
        private readonly IModelManager _manager;

        public CarModelController(IModelManager manager)
        {
            _manager = manager;
        }


        [HttpGet("getall")]
       public List<CarModel> GetAll()
        {

            return _manager.GetAll();


        }

        [HttpGet("get")]
       public CarModel Get([FromForm]int Id) {

           return _manager.GetById(Id);
        
        }

        [HttpPost("addmodel")]
        public void AddModel([FromForm]DtoCarModel model) {
        
        _manager.AddModel(model);
        
        }

        [HttpPut("update")]
        public void UpdateModel([FromForm] DtoCarModel model,[FromForm]int id) {

            _manager.UpdateModel(id, model);
        }

        [HttpDelete("delete")]
        public void DeleteModel([FromForm] int Id) {
        
        _manager.DeleteModel(Id);
        
        }

    }
}
