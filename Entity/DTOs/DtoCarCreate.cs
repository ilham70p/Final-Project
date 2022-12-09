using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DtoCarCreate
    {
        public int BodyTypeId { get; set; }
        public int TransmissionId { get; set; }
        public DateOnly Year { get; set; }
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
        public string Title { get; set; }
        public List<IFormFile> CarImages { get; set; }
        public int OfferTypeId { get; set; }
        public int OwnerTypeId { get; set; }
    }
}
