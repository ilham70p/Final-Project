﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DtoCarCreate
    {
        public string BodyType { get; set; }
        public string Transmission { get; set; }
        public int Year { get; set; }
        public string DriveType { get; set; }
        public string ExteriorColor { get; set; }
        public int Milage { get; set; }
        public float EngineSize { get; set; }
        public string FuelType { get; set; }
        public string Condition { get; set; }
        public string InteriorColor { get; set; }
        public int DealerId { get; set; }
        public string Description { get; set; }
        public int CarModelId { get; set; }
        public int Price { get; set; }
        public List<IFormFile> CarImages { get; set; }
    }
}
