using System;
using System.Collections.Generic;
using System.Text;

namespace netflix.api.application.Interfaces.ApiAuth
{
    public interface IAuthService
    {
        bool CheckUser(string username, string password);
    }
}
