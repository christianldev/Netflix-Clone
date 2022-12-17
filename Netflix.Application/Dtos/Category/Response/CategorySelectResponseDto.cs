using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Application.Dtos.Category.Response
{
    public class CategorySelectResponseDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
    }
}