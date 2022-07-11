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
        public AuthUserResponse User { get; set; }
    }

    public class AuthUserResponse
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }

    }
}