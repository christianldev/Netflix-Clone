using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Application.Dtos.User.Request
{
    public class TokenRequestDto
    {
        // public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}