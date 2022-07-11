using netflix.api.application.Model;
using netflix.api.application.Model.ApiAuth;
using System;
using System.Collections.Generic;
using System.Text;

namespace netflix.api.application.Interfaces.ApiAuth
{
    public interface ITokenService
    {
        string CreateToken(AuthRequest usuario);

    }
}
