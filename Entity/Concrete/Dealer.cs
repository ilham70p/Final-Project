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
    public class Dealer:IEntity { 
    
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }
    [MaxLength(20)]
    public string Mobile { get; set; }
    [MaxLength(20)]
    public string WhatsApp { get; set; }
    [NotMapped]
    public IFormFile ImageFile { get; set; }
    public string ImageName { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public List<Car> Cars { get; set; }

    
    }
}
