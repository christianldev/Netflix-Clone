﻿using netflix_api_application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace netflix_api_application.DTOs
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
        public List<string> Roles { get; set; }

        public bool IsVerified { get; set; }

        public string JWToken { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
