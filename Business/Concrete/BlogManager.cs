using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class BlogManager : IBlogManager
    {
        private readonly IBlogDal _blogDal;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogManager(IBlogDal blogDal,IWebHostEnvironment webHostEnvironment)
        {
            _blogDal = blogDal;
            _webHostEnvironment = webHostEnvironment;
        }

        public void AddBlog(DtoBlogCreate blog)
        {

            string fileName = Guid.NewGuid() + "-" + blog.Image.FileName;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                blog.Image.CopyTo(stream);
            }
            Blog myblog = new Blog {Title = blog.Title,Descriptoin = blog.Description,BlogCategoryId=blog.BlogCategoryId,CreateDate=DateTime.Now,ImageFile = blog.Image,ImageName = fileName };
            _blogDal.Add(myblog);

        }

        public void DeleteBlog(int Id)
        {
            Blog myblog = _blogDal.Get(Id);
            string fileName = myblog.ImageName;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _blogDal.Delete(myblog);

        }

        public List<Blog> GetAllBlogs()
        {
            
            return _blogDal.GetAll();
        }

        public Blog GetBlogById(int Id)
        {
            
            return _blogDal.Get(Id);
        }

        public void UpdateBlog(int Id, DtoBlogCreate blog)
        {
            Blog oldblog = _blogDal.Get(Id);
            //find and delete image
            string oldImageName = oldblog.ImageName;
            string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", oldImageName);
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            string fileName = Guid.NewGuid() + "-" + blog.Image.FileName;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath,"Uploads",fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                blog.Image.CopyTo(stream);
            }

            oldblog.Title = blog.Title;
            oldblog.Descriptoin = blog.Description;
            oldblog.BlogCategoryId = blog.BlogCategoryId;
            oldblog.ImageName = fileName;
            oldblog.ImageFile = blog.Image;
            _blogDal.Update(oldblog);
        }
    }
}
