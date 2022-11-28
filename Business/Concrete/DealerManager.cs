using AutoMapper;
using AutoMapper.Internal.Mappers;
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
    public class DealerManager : IDealerManager
    {
        private readonly IDealerDal _dealerDal;
        private readonly IMapper _mapper;

        public DealerManager(IDealerDal dealerDal,IMapper mapper)
        {
            _dealerDal = dealerDal;
            _mapper = mapper;
        }

        public void AddDealer(DtoDealerCreate dealer)
        {
            _dealerDal.UploadImage(dealer.Image);
                Dealer mydealer = new Dealer {
                    Name=dealer.Name,
                    Email=dealer.Email,
                    WhatsApp=dealer.WhatsApp,
                    Mobile=dealer.Mobile,
                    Location=dealer.Location,
                    Description = dealer.Description,
                    ImageFile=dealer.Image,
                    ImageName= _dealerDal.UploadImage(dealer.Image)
            };


            //var mymodel =_mapper.Map<Dealer>(dealer);
            _dealerDal.Add(mydealer);
        }

        public void DeleteDealer(int id)
        {
           Dealer mydealer = _dealerDal.Get(id);
            _dealerDal.DeleteImage(mydealer.ImageName);
            _dealerDal.Delete(mydealer);
        }

        public List<Dealer> GetAllDealers()
        {
           return _dealerDal.GetAll();
        }

        public Dealer GetDealerById(int id)
        {
            return _dealerDal.Get(id);
        }

        public void UpdateDealer(DtoDealerCreate dealer, int Id)
        {
            _dealerDal.DeleteImage(_dealerDal.Get(Id).ImageName);
            string myimage =   _dealerDal.UploadImage(dealer.Image);

            Dealer mydealer = new Dealer {Name=dealer.Name,Description=dealer.Description,Email=dealer.Email,WhatsApp=dealer.WhatsApp,Mobile=dealer.Mobile,Location=dealer.Location,ImageFile=dealer.Image,ImageName=myimage };
            _dealerDal.Update(mydealer);
        }
    }
}
