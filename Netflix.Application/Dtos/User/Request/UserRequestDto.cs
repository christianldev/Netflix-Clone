using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.Application.Dtos.User.Request
{
    public class UserRequestDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

        public DateTime? Birthdate { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? Image { get; set; }

    }
}