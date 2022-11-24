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
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureManager _manager;

        public FeatureController(IFeatureManager manager)
        {
            _manager = manager;
        }



        [HttpGet("getall")]
       public List<Feature> GetAll()
        {
            return _manager.GetAllFeatures();
        }


        [HttpGet("Get")]
       public Feature Get(int id)
        {
            return _manager.GetFeature(id);
        }

        [HttpPost("add")]
        public void Add([FromForm] Feature feature)
        {
            _manager.AddFeature(feature);
        }

        [HttpPut("update")]
        public void Update([FromForm]int id,[FromForm]Feature feature) {
            _manager.UpdateFeature(feature, id);
        }

        [HttpDelete("delete")]
        public void Delete([FromForm]int id)
        {
            _manager.DeleteFeature(id);
        }
    }
}
