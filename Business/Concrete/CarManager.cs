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
            Car mycar = new Car {BodyTypeId = car.BodyTypeId, 
                                 TransmissionId = car.TransmissionId,
                                 Year = car.Year, 
                                 DriveTypeId = car.DriveTypeId, 
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
                                 Title= car.Title,
                                 OwnerTypeId=car.OwnerTypeId,
                                 OfferTypeId=car.OfferTypeId,
                                 PostDate=DateTime.Now
            };
            
            _carDal.Add(mycar);
            int carId = mycar.Id;

            foreach (var item in car.CarImages)
            {
                _manager.AddCarImage(item,carId);
            }

        }

        public void UpdateCar(int id, DtoCarCreate car)
        {
          Car oldCar = _carDal.Get(id);
            if (car.CarImages!=null)
            {
                foreach (var item in oldCar.CarImages)
                {
                    _manager.DeleteImage(item.Id);
                }


                    oldCar.BodyTypeId = car.BodyTypeId;
                    oldCar.TransmissionId = car.TransmissionId;
                    oldCar.Year = car.Year;
                    oldCar.DriveTypeId = car.DriveTypeId;
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
                oldCar.OfferTypeId = car.OfferTypeId;
                oldCar.OwnerTypeId = car.OwnerTypeId;
                
                



                _carDal.Update(oldCar);
               
                foreach (var item in car.CarImages)
                {
                    _manager.AddCarImage(item, oldCar.Id);
                }
            }
            else
            {


                oldCar.BodyTypeId = car.BodyTypeId;
                oldCar.TransmissionId = car.TransmissionId;
                oldCar.Year = car.Year;
                oldCar.DriveTypeId = car.DriveTypeId;
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
                oldCar.OfferTypeId = car.OfferTypeId;
                oldCar.OwnerTypeId = car.OwnerTypeId;
                _carDal.Update(oldCar);
            }

        }

        public void DeleteCar(int Id)
        {
            var oldCar = _carDal.Get(Id);
            foreach (var item in oldCar.CarImages)
            {
                _manager.DeleteImage(item.Id);
            }
            _carDal.Delete(oldCar);
        }

        public List<DtoCar> GetAllCars()
        {
            return _carDal.GetAllCar();
        }

        public DtoCar GetCarById(int Id)
        {
            return _carDal.GetCar(Id);
        }

        public List<DtoCar> GetCarsByPage(int pageNumber, int pageSize)
        {
            return _carDal.GetAllCar().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Car> Filter(string? q, decimal? minPrice, decimal? maxPrice, int? sortBy, int? brandId, bool? condition, int? bodyTypeId, DateTime? year, int? transmissionId, int? driveTypeId, int? minMilage, int? maxMilage, int? ownerTypeId, bool? sellerType, int? offerTypeId)
        {
            return _carDal.Filter(q, minPrice, maxPrice, sortBy, brandId, condition, bodyTypeId, year, transmissionId, driveTypeId, minMilage, maxMilage, ownerTypeId, sellerType, offerTypeId);
        }
    }
}
