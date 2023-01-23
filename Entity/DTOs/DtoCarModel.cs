﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DtoCarModel
    {
        public string Name { get; set; }
        public DtoBrand Brand { get; set; }
        public Feature Feature { get; set; }
    }
}
