using Microsoft.AspNetCore.Http;
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
    public class CarImage:IEntity
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string Base64Image { get; set; }
        public string ImageName { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }
        [Required]
        public Car Car { get; set; }


    }
}
