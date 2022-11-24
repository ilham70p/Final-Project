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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ServiceController(IServiceManager manager)
        {
            _manager = manager;
        }



        [HttpGet("getall")]
       public List<Service> GetAll()
        {
            return _manager.GetAllServices();
        }


        [HttpGet("getbyid")]
       public Service GetById(int id)
        {
            return _manager.GetServiceById(id);
        }

        [HttpPost("add")]
        public void Add([FromForm] Service service)
        {
            _manager.AddService(service);
        }

     

        [HttpDelete("delete")]
        public void Delete([FromForm] int Id)
        {

            _manager.DeleteService(Id);
        }

        [HttpPut("update")]
        public void Update(int Id, [FromForm] Service service)
        {

            _manager.UpdateService(service, Id);

        }


    }
}
