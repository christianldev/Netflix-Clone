using netflix.api.application.Interfaces.ApiAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace netflix.api.application.AppServices.ApiAuth
{
    public class AuthService : IAuthService
    {
        public bool CheckUser(string username, string password)
        {
            return username.Equals("admin") && password.Equals("admin");
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var encrypt = new HMACSHA512())
            {
                passwordSalt = encrypt.Key;
                passwordHash = encrypt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var viewEncrypt = new HMACSHA512(passwordSalt))
            {
                var computedHash = viewEncrypt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
