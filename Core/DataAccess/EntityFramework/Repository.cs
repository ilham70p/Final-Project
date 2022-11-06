using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace Core.DataAccess.EntityFramework
{
    public class Repository<TModel, TContext> : IRepository<TModel> where TModel : class, IEntity, new()
        where TContext : DbContext, new()
    {
        
        public List<TModel> GetAll()
        {

            using TContext context = new TContext();
            var getget = context.Set<TModel>().ToList();
            return getget;
        }

        public TModel Get(int Id)
        {
            using TContext context = new TContext();
            var mymodel = context.Set<TModel>().Find(Id);
            return mymodel;
        }


        public void Add(TModel model)
        {
            /* using TContext context = new();
             var addEntity = context.Entry(entity);
             addEntity.State = EntityState.Added;
             context.SaveChanges();
            */

            using TContext context = new TContext();
            var getget = context.Set<TModel>().Add(model);
            context.SaveChanges();
            
        }

        public void Delete(TModel entity)
        {
            using TContext context = new();
            var deleteEntity = context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }


        
       

        public void Update(TModel entity)
        {
            using TContext context = new TContext();
            var getget = context.Set<TModel>().Update(entity);
            context.SaveChanges();
        }
    }

}
