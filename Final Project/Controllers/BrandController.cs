using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class BrandController : ControllerBase
    {
        private readonly IBrandManager _manager;

        public BrandController(IBrandManager manager)
        {
            _manager = manager;
        }

        
        [HttpGet("getall")]
       public List<Brand> GetAll()
        {
            return _manager.GetAllBrand();
        }


        [HttpGet("getbyid")]
      public  Brand GetById(int id)
        {
            return _manager.GetBrandById(id);
        }

        [HttpPost("add")]
        public void Add([FromForm] DtoBrandCreate brand)
        {
            _manager.AddBrand(brand);
        }

        [HttpPut("update")]
        public void Update([FromForm] int Id,[FromForm] DtoBrandCreate brand) {

            _manager.UpdateBrand(brand,Id);
        
        }

        [HttpDelete("delete")]
        public void Delete([FromForm] int Id) { 
        
        _manager.DeleteBrand(Id);
        }

    }
}
