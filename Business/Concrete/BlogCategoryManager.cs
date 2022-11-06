using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogCategoryManager : IBlogCategoryManager
    {
        private readonly IBlogCategoryDal _blogCategoryDal;

        public BlogCategoryManager(IBlogCategoryDal blogCategoryDal)
        {
            _blogCategoryDal = blogCategoryDal;
        }

        public void AddBlogCategory(DtoBlogCategory blogCategory)
        {
            BlogCategory blog = new BlogCategory { 
            Name = blogCategory.Name,
            };
            _blogCategoryDal.Add(blog);
        }

        public void DeleteBlogCategory(int Id)
        {
            BlogCategory myblog = _blogCategoryDal.Get(Id);
            _blogCategoryDal.Delete(myblog);
        }

        public List<BlogCategory> GetAll()
        {
            return _blogCategoryDal.GetAll();
        }

        public BlogCategory GetById(int id)
        {
            return _blogCategoryDal.Get(id);
        }

        public void UpdateBlogCategory(int Id, DtoBlogCategory blogCategory)
        {
            BlogCategory myblog = _blogCategoryDal.Get(Id);
            myblog.Name = blogCategory.Name;
            _blogCategoryDal.Update(myblog); 
        }


    }
}
