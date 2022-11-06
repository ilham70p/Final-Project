﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DtoBlogCreate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int BlogCategoryId { get; set; }
        public IFormFile Image { get; set; }
    }
}
