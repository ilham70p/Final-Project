using AutoMapper;
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
    public class CarManager : ICarManager
    {
        private readonly ICarDal _carDal;
        private readonly ICarImageManager _manager;
        private readonly IMapper _mapper;

        public CarManager(ICarDal carDal,ICarImageManager manager,IMapper mapper)
        {      
            _carDal = carDal;
            _manager = manager;
            _mapper = mapper;
        }
        public void AddCar(DtoCarCreate car)
        {
            Car mycar = new Car {BodyType = car.BodyType, 
                                 Transmission = car.Transmission,
                                 Year = car.Year, 
                                 DriveType = car.DriveType, 
                                 ExteriorColor = car.ExteriorColor,
                                 Milage=car.Milage,
                                 EngineSize=car.EngineSize,
                                 FuelType=car.FuelType,
                                 Condition=car.Condition,
                                 InteriorColor=car.InteriorColor,
                                 DealerId=car.DealerId,
                                 Description=car.Description,
                                 CarModelId=car.CarModelId,
                                 Price=car.Price,
                                 Title= car.Title  
            };
            
            _carDal.Add(mycar);
            int carId = mycar.Id;

            foreach (var item in car.CarImages)
            {
                _manager.AddCarImage(item,carId);
            }

        }

        public void UpdateCar(int Id, DtoCarCreate car)
        {
          Car oldCar =  _carDal.GetCar(Id);
            if (car.CarImages!=null)
            {
                foreach (var item in oldCar.CarImages)
                {
                    _manager.DeleteImage(item.Id);
                }


                    oldCar.BodyType = car.BodyType;
                    oldCar.Transmission = car.Transmission;
                    oldCar.Year = car.Year;
                    oldCar.DriveType = car.DriveType;
                    oldCar.ExteriorColor = car.ExteriorColor;
                    oldCar.Milage = car.Milage;
                    oldCar.EngineSize = car.EngineSize;
                    oldCar.FuelType = car.FuelType;
                    oldCar.Condition = car.Condition;
                    oldCar.InteriorColor = car.InteriorColor;
                    oldCar.DealerId = car.DealerId;
                    oldCar.Description = car.Description;
                    oldCar.CarModelId = car.CarModelId;
                    oldCar.Price = car.Price;
                



                _carDal.Update(oldCar);
               
                foreach (var item in car.CarImages)
                {
                    _manager.AddCarImage(item, oldCar.Id);
                }
            }
            else
            {


                oldCar.BodyType = car.BodyType;
                oldCar.Transmission = car.Transmission;
                oldCar.Year = car.Year;
                oldCar.DriveType = car.DriveType;
                oldCar.ExteriorColor = car.ExteriorColor;
                oldCar.Milage = car.Milage;
                oldCar.EngineSize = car.EngineSize;
                oldCar.FuelType = car.FuelType;
                oldCar.Condition = car.Condition;
                oldCar.InteriorColor = car.InteriorColor;
                oldCar.DealerId = car.DealerId;
                oldCar.Description = car.Description;
                oldCar.CarModelId = car.CarModelId;
                oldCar.Price = car.Price;

                _carDal.Update(oldCar);
            }

        }

        public void DeleteCar(int Id)
        {
            Car oldCar = _carDal.GetCar(Id);
            foreach (var item in oldCar.CarImages)
            {
                _manager.DeleteImage(item.Id);
            }
            _carDal.Delete(oldCar);
        }

        public List<Car> GetAllCars()
        {
            return _carDal.GetAllCar();
        }

        public Car GetCarById(int Id)
        {
            var car = _carDal.GetCar(Id);
            return car;
        }

        public List<Car> GetCarsByPage(int pageNumber, int pageSize)
        {
            return _carDal.GetAllCar().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Car> Filter(int? categoryId, string? q, decimal? minPrice, decimal? maxPrice, int? sortBy, int? brandID, string? condition, string? bodyType, int? year, string? transmission, string? driveType, int? milage, string? ownerType, string? sellerType)
        {
           
            List<Car> cars = _carDal.GetAll();
            //if (!String.IsNullOrEmpty(q))
            //{
            //    cars = cars.Where(cars.title)
            //}
            return cars;
        }
    }
}
