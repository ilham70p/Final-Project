﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string BodyType { get; set; }
        public string Title { get; set; }
        [MaxLength(15)]
        public string Transmission { get; set; }
        public int Year { get; set; }
        [MaxLength(10)]
        public string DriveType { get; set; }
        [MaxLength(20)]
        public string ExteriorColor { get; set; }
        public int Milage { get; set; }
        public float EngineSize { get; set; }
        [MaxLength(20)]
        public string FuelType { get; set; }
        [MaxLength(20)]
        public string Condition { get; set; }
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
    }
}
