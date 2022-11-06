using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IBlogCategoryManager _manager;

        public HomeController(IBlogCategoryManager manager)
        {
            _manager = manager;
        }
        [HttpGet("getall")]
        public List<BlogCategory> GetAll()
        {
            return _manager.GetAll();
        }

        [HttpGet("getbyid")]
        public BlogCategory GetById(int id)
        {
            return _manager.GetById(id);
        }

        [HttpPost("add")]
        public void Add([FromForm]DtoBlogCategory model) {
            _manager.AddBlogCategory(model);
        }

        [HttpPut("update")]
        public void Update([FromForm] DtoBlogCategory model,[FromForm]int Id)
        {
            _manager.UpdateBlogCategory(Id,model);
        }

        [HttpDelete("delete")]
        public void Delete([FromForm]int id)
        {
            _manager.DeleteBlogCategory(id);
        }
    }
}
