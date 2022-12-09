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
    public class TransmissionController : ControllerBase
    {
        private readonly ITransmissionManager _manager;

        public TransmissionController(ITransmissionManager manager)
        {
            _manager = manager;
        }



        [HttpGet("getall")]
       public List<Transmission> GetAll()
        {
            return _manager.GetAllTransmissions();
        }


        [HttpGet("Get")]
       public Transmission Get(int id)
        {
            return _manager.GetTransmission(id);
        }

        [HttpPost("add")]
        public void Add([FromForm] Transmission Transmission)
        {
            _manager.AddTransmission(Transmission);
        }

        [HttpPut("update")]
        public void Update([FromForm]int id,[FromForm]Transmission Transmission) {
            _manager.UpdateTransmission(Transmission, id);
        }

        [HttpDelete("delete")]
        public void Delete([FromForm]int id)
        {
            _manager.DeleteTransmission(id);
        }
    }
}
