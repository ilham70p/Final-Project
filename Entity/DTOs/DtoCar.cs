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
        public int BodyTypeId { get; set; }
        public int TransmissionId { get; set; }
        public DateTime Year { get; set; }
        public int DriveTypeId { get; set; }
        public string ExteriorColor { get; set; }
        public int Milage { get; set; }
        public float EngineSize { get; set; }
        public string FuelType { get; set; }
        public bool Condition { get; set; }
        public string InteriorColor { get; set; }
        public int DealerId { get; set; }
        public string Description { get; set; }
        public int CarModelId { get; set; }
        public int Price { get; set; }
        public List<string> CarImages { get; set; }
        public int OfferTypeId { get; set; }
        public int OwnerTypeId { get; set; }
    }
}
