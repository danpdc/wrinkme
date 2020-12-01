using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using WrinkMe.Domain.Models;

namespace WrinkMe.Domain.Utils
{
    public class PasswordHasher
    {
        private readonly User _user;
        public PasswordHasher(User user)
        {
            _user = user;
        }

        public string HashPassword(string password)
        {
            var salt = _user.UserId.ToByteArray();
            var hashed = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 10000, 32);
            return Convert.ToBase64String(hashed);
        }

        public bool VerifyPasswordMatch(string passwordToVerify)
        {
            var salt = _user.UserId.ToByteArray();
            var hashed = KeyDerivation.Pbkdf2(passwordToVerify, salt, KeyDerivationPrf.HMACSHA512, 10000, 32);
            return Convert.ToBase64String(hashed) == _user.Password;
        }
    }
}
