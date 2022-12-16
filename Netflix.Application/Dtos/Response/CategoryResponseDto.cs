using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Application.Dtos.Response
{
    public class CategoryResponseDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int State { get; set; }
        public string? StateCategory { get; set; }
    }
}