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
    public class CarModel:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        [Required]
        public Brand Brand { get; set; }
        public List<Car> Cars { get; set; }
        public List<Feature> Features { get; set; }
    }
}
