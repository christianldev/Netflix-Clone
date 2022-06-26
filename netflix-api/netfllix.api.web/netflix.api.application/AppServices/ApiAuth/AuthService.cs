using netflix.api.application.Interfaces.ApiAuth;
using System;
using System.Collections.Generic;
using System.Text;

namespace netflix.api.application.AppServices.ApiAuth
{
    public class AuthService : IAuthService
    {
        public bool CheckUser(string username, string password)
        {
            return username.Equals("admin") && password.Equals("admin");
        }
    }
}
