using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;

namespace Entities.Concrete
{
    public enum Color
    {
        Red,
        Green,
        Yellow
    }
    public class Car:IEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public int BodyTypeId { get; set; }
        public BodyType BodyType { get; set; }
        public string Title { get; set; }
        [MaxLength(15)]
        public int TransmissionId { get; set; }
        public Transmission Transmission { get; set; }
        public DateTime Year { get; set; }
        public DateTime PostDate { get; set; }
        [MaxLength(10)]
        public int DriveTypeId { get; set; }
        public DrivingType DriveType { get; set; }
        [MaxLength(20)]
        public string ExteriorColor { get; set; }
        public int Milage { get; set; }
        public float EngineSize { get; set; }
        [MaxLength(20)]
        public string FuelType { get; set; }
        [MaxLength(20)]
        public bool Condition { get; set; } //false - new, true - used
        [MaxLength(20)]
        public string InteriorColor { get; set; }
        [ForeignKey("Dealer")]
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
        public string Description { get; set; }
        public List<CarImage> CarImages { get; set; }

        [ForeignKey("CarModel")]
        [Required]
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
        public int Price { get; set; }
        //public Color Color { get; set; }
        public bool SellerType { get; set; }//false - individual, true - dealer
        // how to implement this....
        // wait to implement what!?!?!?! i already forgor
        // Oh right the color!
        public int OfferTypeId { get; set; }
        public OfferType OfferType { get; set; }
        public int OwnerTypeId { get; set; }
        public OwnerType OwnerType { get; set; }
    }

    
}
