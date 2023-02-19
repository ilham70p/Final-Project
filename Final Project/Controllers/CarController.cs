﻿using Business.Abstract;
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
        private readonly IWebHostEnvironment _environment;
        private readonly ICarManager _manager;

        public CarController(ICarManager manager, IWebHostEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }

        [HttpGet("getall")]
        public List<DtoCar> GetAll()
        {
            var cars = _manager.GetAllCars();

            return cars;

        }

        [HttpGet("get")]
        public DtoCar Get(int id)
        {

            return _manager.GetCarById(id);

        }
        [HttpGet("getbypage")]
        public List<DtoCar> GetCarsByPage([FromQuery] int page, [FromQuery] int pageSize)
        {
            return _manager.GetCarsByPage(page, pageSize);
        }
        [HttpGet("Filter")]
        public List<Car> Filter([FromQuery] string? q, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice, [FromQuery] int? sortBy, [FromQuery] int? brandId, [FromQuery] bool? condition, [FromQuery] int? bodyTypeId, [FromQuery] DateTime? year, [FromQuery] int? transmissionId, [FromQuery] int? driveTypeId, [FromQuery] int? minMilage, [FromQuery] int? maxMilage, [FromQuery] int? ownerTypeId, [FromQuery] bool? sellerType, [FromQuery] int? offerTypeId)
        {
            return _manager.Filter(q, minPrice, maxPrice, sortBy,brandId,condition,bodyTypeId, year, transmissionId,  driveTypeId, minMilage, maxMilage, ownerTypeId, sellerType, offerTypeId);
        }
        [HttpPost("post")]
        public void Post([FromForm] DtoCarCreate car)
        {

            _manager.AddCar(car);

        }

        [HttpPut("update")]
        public void Update([FromForm] int id, [FromForm] DtoCarCreate car)
        {


            _manager.UpdateCar(id, car);


        }
        [HttpDelete("delete")]
        public void Delete([FromForm] int Id)
        {

            _manager.DeleteCar(Id);
        }
        [HttpPost("uploadimages")]
        public string UploadImages(IFormFile Image)
        {
            string path = "/Uploads/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                Image.CopyTo(fileStream);
            }

            List<string> photos = new();

            return path;

        }
    }
}
