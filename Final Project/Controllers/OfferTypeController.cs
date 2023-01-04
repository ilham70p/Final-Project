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
    public class OfferTypeController : ControllerBase
    {
        private readonly IOfferTypeManager _manager;

        public OfferTypeController(IOfferTypeManager manager)
        {
            _manager = manager;
        }



        [HttpGet("getall")]
       public List<OfferType> GetAll()
        {
            return _manager.GetAllOfferTypes();
        }


        [HttpGet("get")]
       public OfferType Get(int id)
        {
            return _manager.GetOfferType(id);
        }

        [HttpPost("add")]
        public void Add([FromForm] OfferType OfferType)
        {
            _manager.AddOfferType(OfferType);
        }

        [HttpPut("update")]
        public void Update([FromForm]int id,[FromForm]OfferType OfferType) {
            _manager.UpdateOfferType(OfferType, id);
        }

        [HttpDelete("delete")]
        public void Delete([FromForm]int id)
        {
            _manager.DeleteOfferType(id);
        }
    }
}
