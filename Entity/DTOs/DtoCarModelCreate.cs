using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DtoCarModelCreate
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int FeatureId { get; set; }
    }
}
