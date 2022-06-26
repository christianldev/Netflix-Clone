using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflix.api.application.Model
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string MensajeError { get; set; }
        public User User { get; set; }
    }

    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }


    }
}