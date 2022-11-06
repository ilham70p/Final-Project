using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly IBlogManager _manager;

        public BlogController(IBlogManager manager)
        {
            _manager = manager;
        }


        [HttpGet("getall")]
       public List<Blog>GetAll(){

            return _manager.GetAllBlogs();

            }

        [HttpGet("getbyid")]
        public Blog Get(int id) {

            return _manager.GetBlogById(id);
        
        }

        [HttpPost("add")]
        public void Add([FromForm]DtoBlogCreate blog) {

            _manager.AddBlog(blog);

        }

        [HttpPut("update")]
        public void Update([FromForm]int Id,[FromForm]DtoBlogCreate blog) {

            _manager.UpdateBlog(Id, blog);
        }

        [HttpDelete("delete")]
        public void Delete([FromForm] int Id) {
                
            _manager.DeleteBlog(Id);
        
        }



    }
}
