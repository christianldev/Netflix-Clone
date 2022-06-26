using netflix.api.application.Model;
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
