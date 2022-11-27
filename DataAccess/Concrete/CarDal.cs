

using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CarDal : Repository<Car,AppDbContext>, ICarDal
    {
     

       


        public List<Car> GetAllCars()
        {

            using (AppDbContext context = new()) {

                return context.Cars.Include(c => c.CarImages).ToList();

            }
          
        }

        public Car? GetCar(int id)
        {

            using (AppDbContext context = new())
            {

                return context.Cars.Include(b => b.CarImages).Where(a => a.Id == id).FirstOrDefault();

            }

           
        }






       







    }
}
