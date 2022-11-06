using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogManager
    {
        List<Blog> GetAllBlogs();
        Blog GetBlogById(int Id);
        void AddBlog(DtoBlogCreate blog);
        void UpdateBlog(int Id, DtoBlogCreate blog);
        void DeleteBlog(int Id);

    }
}
