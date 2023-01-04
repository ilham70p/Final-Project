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
    public class BlogCategoryController : ControllerBase
    {
        private readonly IBlogCategoryManager _manager;

        public BlogCategoryController(IBlogCategoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet("getall")]
        public List<BlogCategory> GetAll() { 
                        
            return _manager.GetAll();
        }

        [HttpGet("get")]
        public BlogCategory Get(int Id) {
            return _manager.GetById(Id);
        
        }

        [HttpPost("add")]
        public void Post([FromForm]DtoBlogCategory category) {

            _manager.AddBlogCategory(category);
        }

        [HttpPut("update")]
        public void Put([FromForm] DtoBlogCategory category,[FromForm] int Id)
        {
            _manager.UpdateBlogCategory(Id, category);

        }

        [HttpDelete("delete")]
        public void Delete([FromForm] int Id)
        {
            _manager.DeleteBlogCategory(Id);
        }
    }
}
