using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DtoCar
    {
        public int Id { get; set; }
        public string BodyType { get; set; }
        public string Transmission { get; set; }
        public DateTime Year { get; set; }
        public string DriveType { get; set; }
        public string ExteriorColor { get; set; }
        public int Milage { get; set; }
        public float EngineSize { get; set; }
        public string FuelType { get; set; }
        public bool Condition { get; set; }
        public string InteriorColor { get; set; }
        public string Dealer { get; set; }
        public string Description { get; set; }
        public string CarModel { get; set; }
        public int Price { get; set; }
        public List<string> CarImages { get; set; }
        public string OfferType { get; set; }
        public string OwnerType { get; set; }
        public bool SellerType { get; set; }
        public DateTime PostDate { get; set; }
    }
}
