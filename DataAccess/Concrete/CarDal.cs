

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
                        Year = cars[i].Year,
                        ExteriorColor = cars[i].ExteriorColor,
                        Milage = cars[i].Milage,
                        EngineSize = cars[i].EngineSize,
                        FuelType = cars[i].FuelType,
                        Condition = cars[i].Condition,
                        InteriorColor = cars[i].InteriorColor,
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
                var cars = context.Cars.Include(c => c.CarImages).Include(c => c.Dealer).Include(c => c.CarModel).ThenInclude(c => c.Brand).Include(c => c.BodyType).Include(c => c.DriveType).Include(c => c.OfferType).Include(c => c.OwnerType).Include(c => c.Transmission).FirstOrDefault(c => c.Id == id);
                var images = context.CarImages.Where(c => c.CarId == id).ToList();

                //    Car car = cars[i];
                //    List<CarImage> pic = cars[i].CarImages;
                List<string> pics = new();
                foreach (CarImage img in images.Where(c => c.CarId == cars.Id))
                {
                    pics.Add(img.Base64Image);
                }

                Dealer dealer = cars.Dealer;
                DtoDealer dtodealer = new()
                {
                    Name = dealer.Name,
                    Mobile = dealer.Mobile,
                    Id = dealer.Id,
                    Email = dealer.Email,
                    WhatsApp = dealer.WhatsApp,
                    Image = dealer.Base64Image,
                    Location = dealer.Location,
                    Description = dealer.Description,
                };
                CarModel model = cars.CarModel;
                DtoBrand dtoBrand = new() 
                {
                    Id = model.BrandId,
                    Name = model.Brand.Name,
                    Image = model.Brand.Base64Image
                };
                DtoCarModel dtomodel = new()
                {
                    Feature = model.Feature,
                    Brand = dtoBrand
                };

                DtoCar result = new()
                {
                    Id = cars.Id,
                    Year = cars.Year,
                    ExteriorColor = cars.ExteriorColor,
                    Milage = cars.Milage,
                    EngineSize = cars.EngineSize,
                    FuelType = cars.FuelType,
                    Condition = cars.Condition,
                    InteriorColor = cars.InteriorColor,
                    Price = cars.Price,
                    Description = cars.Description,
                    CarImages = pics,
                    Dealer = dtodealer,
                    CarModel = dtomodel,
                    PostDate = DateTime.Now,
                };
                return result;
            }
        }

        public List<Car> Filter(string? q, decimal? minPrice, decimal? maxPrice, int? sortBy, int? brandId, bool? condition, int? bodyTypeId, DateTime? year, int? transmissionId, int? driveTypeId, int? minMilage, int? maxMilage, int? ownerTypeId, bool? sellerType, int? offerTypeId)
        {
            using (AppDbContext context = new())
            {
                var cars = context.Cars.Include(c => c.CarImages).AsQueryable();
                var result = new List<Car>();

                if (!string.IsNullOrEmpty(q))
                {
                    result.AddRange(cars.Where(c => c.Title.Contains(q)));                 
                }
                if (brandId.HasValue)
                {
                    result.AddRange(cars.Where(c => c.CarModel.BrandId == brandId).ToList());
                }
                if (minPrice.HasValue && maxPrice.HasValue)
                {
                    
                    result.AddRange(cars.Where(c => c.Price >= minPrice && c.Price <= maxPrice).ToList());
                }
                if (minMilage.HasValue && maxMilage.HasValue)
                {
                    result.AddRange(cars.Where(c => c.Milage >= minMilage && c.Milage <= maxMilage).ToList());
                }

                if (sellerType.HasValue)
                {
                    result.AddRange(cars.Where(c => c.SellerType == sellerType).ToList());
                }

                if (condition.HasValue)
                {
                    result.AddRange(cars.Where(c => c.Condition == condition).ToList());
                }

                if (offerTypeId.HasValue)
                {
                    result.AddRange(cars.Where(c => c.OfferTypeId == offerTypeId).ToList());
                }
                if (bodyTypeId.HasValue)
                {
                    result.AddRange(cars.Where(c => c.BodyTypeId == bodyTypeId).ToList());
                }
                if (driveTypeId.HasValue)
                {
                    result.AddRange(cars.Where(c => c.DriveTypeId == driveTypeId).ToList());
                }
                if (ownerTypeId.HasValue)
                {
                    result.AddRange(cars.Where(c => c.OwnerTypeId == ownerTypeId).ToList());
                }
                if (offerTypeId.HasValue)
                {
                    result.AddRange(cars.Where(c => c.OfferTypeId == offerTypeId).ToList());
                }//replace to fueltype
                if (transmissionId.HasValue)
                {
                    result.AddRange(cars.Where(c => c.TransmissionId == transmissionId).ToList());
                }
                if (year.HasValue)
                {
                    result.AddRange(cars.Where(c => c.Year.Year == year.Value.Year).ToList());
                }

                if (sortBy.HasValue)
                {
                    cars = sortBy.Value switch
                    {
                        1 => cars.OrderByDescending(c => c.PostDate),
                        2 => cars.OrderBy(c => c.PostDate),
                        3 => cars.OrderByDescending(c => c.Price),
                        4 => cars.OrderBy(c => c.Price),
                        5 => cars.OrderByDescending(c => c.Milage),
                        6 => cars.OrderBy(c => c.Milage),
                        7 => cars.OrderByDescending(c => c.Year),
                        8 => cars.OrderBy(c => c.Year),
                        _ => cars.OrderByDescending(c => c.PostDate),
                    };
                    result.AddRange(cars.ToList());
                }

                return result;
            }
        }



        //public List<Blog> Similar(int catId, string userId, int blogId)
        //{
        //    return _context.Blogs.OrderByDescending(x => x.Hit).Include(x => x.Category).Include(x => x.K205User)
        //        .Where(x => x.CategoryID == catId && x.K205UserId == userId && x.ID != blogId).Take(2).ToList();
        //}

    }
}
