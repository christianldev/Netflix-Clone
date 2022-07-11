using System;
using System.Collections.Generic;
using System.Text;

namespace netflix.api.application.Interfaces.ApiAuth
{
    public interface IAuthService
    {
        bool CheckUser(string username, string password);

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
    }
}
