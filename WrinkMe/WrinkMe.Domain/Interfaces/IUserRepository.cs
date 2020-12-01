using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WrinkMe.Domain.Models;

namespace WrinkMe.Domain
{
    public interface IUserRepository
    {
        Task<UserProfile> Login(string username, string password);
        Task<User> SignUp(string username, string password, string email);
    }
}
