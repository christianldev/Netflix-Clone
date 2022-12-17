using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Application.Dtos.Category.Request
{
    public class CategoryRequestDto
    {
        public string? Name { get; set; }
        public int State { get; set; }
    }
}