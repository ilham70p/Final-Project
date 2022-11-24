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
    public class DealerController : ControllerBase
    {
        private readonly IDealerManager _manager;

        public DealerController(IDealerManager manager)
        {
            _manager = manager;
        }

        [HttpGet("getall")]
       public List<Dealer> GetAll() { 
        
        return _manager.GetAllDealers();
        
        }


        [HttpGet("get")]
       public Dealer Get(int id) {
            return _manager.GetDealerById(id);
        }

        [HttpPost("add")]
        public void Add([FromForm] DtoDealerCreate dealer) {


            _manager.AddDealer(dealer);
        }

        [HttpPut("update")]
        public void Update([FromForm] DtoDealerCreate dealer,[FromForm] int Id) { 
        
        _manager.UpdateDealer(dealer, Id);
        }

        [HttpDelete("delete")]
        public void Delete([FromForm] int id) {
            _manager.DeleteDealer(id);
        }

    }
}
