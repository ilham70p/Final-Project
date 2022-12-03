

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

        public List<DtoCar> GetAllCar()
        {
            using (AppDbContext context = new()) {
                var cars = context.Cars.Include(c => c.CarImages).Include(c=>c.Dealer).Include(c=>c.CarModel).ToList();
                var images = context.CarImages;
                List<DtoCar> result = new ();

                for (int i = 0; i < cars.Count; i++)
                {
                    List<string> pics = new();
                    foreach (CarImage img in images.Where(c=>c.CarId == cars[i].Id))
                    {
                        pics.Add(img.Base64Image);
                    }
                    DtoCar carList = new()
                    {
                        Id = cars[i].Id,
                        BodyType = cars[i].BodyType,
                        Transmission = cars[i].Transmission,
                        Year = cars[i].Year,
                        DriveType = cars[i].DriveType,
                        ExteriorColor = cars[i].ExteriorColor,
                        Milage = cars[i].Milage,
                        EngineSize = cars[i].EngineSize,
                        FuelType = cars[i].FuelType,
                        Condition = cars[i].Condition,
                        InteriorColor = cars[i].InteriorColor,
                        DealerId = cars[i].DealerId,
                        CarModelId = cars[i].CarModelId,
                        Price = cars[i].Price,
                        Description = cars[i].Description,
                        CarImages = pics
                    };
                    result.Add(carList);
                }
                return result;
            }
        }

        public DtoCar? GetCar(int id)
        {
            using (AppDbContext context = new())
            {
                var cars = context.Cars.Include(c => c.CarImages).Include(c => c.Dealer).Include(c => c.CarModel).FirstOrDefault(c => c.Id == id);
                var images = context.CarImages.Where(c => c.CarId == id).ToList();

                //    Car car = cars[i];
                //    List<CarImage> pic = cars[i].CarImages;
                List<string> pics = new();
                foreach (CarImage img in images.Where(c => c.CarId == cars.Id))
                {
                    pics.Add(img.Base64Image);
                }
                DtoCar result = new()
                {
                    Id = cars.Id,
                    BodyType = cars.BodyType,
                    Transmission = cars.Transmission,
                    Year = cars.Year,
                    DriveType = cars.DriveType,
                    ExteriorColor = cars.ExteriorColor,
                    Milage = cars.Milage,
                    EngineSize = cars.EngineSize,
                    FuelType = cars.FuelType,
                    Condition = cars.Condition,
                    InteriorColor = cars.InteriorColor,
                    DealerId = cars.DealerId,
                    CarModelId = cars.CarModelId,
                    Price = cars.Price,
                    Description = cars.Description,
                    CarImages = pics
                };
                return result;
            }
        }

        public List<Car> Filter(int? categoryId, string? q, decimal? minPrice, decimal? maxPrice, int? sortBy, int? brandId, string? condition, string? bodyType, int? year, string? transmission, string? driveType, int? milage, string? ownerType, string? sellerType)
        {
            using (AppDbContext context = new())
            {
                var cars = context.Cars.Include(c => c.CarImages).AsQueryable();
                if (!String.IsNullOrEmpty(q))
                {
                    cars = cars.Where(c => c.Title.Contains(q));
                }
                if (brandId.HasValue)
                {
                    cars = cars.Where(c => c.CarModel.BrandId == brandId);
                }
                if (minPrice.HasValue && maxPrice.HasValue)
                {
                    cars = cars.Where(c => c.Price >= minPrice && c.Price <= maxPrice);
                }

                return cars.ToList();
            }
        }
        //public List<Blog> Similar(int catId, string userId, int blogId)
        //{
        //    return _context.Blogs.OrderByDescending(x => x.Hit).Include(x => x.Category).Include(x => x.K205User)
        //        .Where(x => x.CategoryID == catId && x.K205UserId == userId && x.ID != blogId).Take(2).ToList();
        //}

    }
}
