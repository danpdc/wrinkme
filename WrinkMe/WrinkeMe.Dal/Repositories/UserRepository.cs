using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrinkMe.Domain;
using WrinkMe.Domain.Models;
using WrinkMe.Domain.Utils;

namespace WrinkeMe.Dal.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly WrinkMeDataContext _ctx;
        public UserRepository(IDbContextFactory<WrinkMeDataContext> ctx)
        {
            _ctx = ctx.CreateDbContext();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public async Task<UserProfile> Login(string username, string password)
        {
            var user = await _ctx.Users.Where(u => u.Username == username.ToLower()).FirstOrDefaultAsync();
            if (user == null)
                return null;
            var hasher = new PasswordHasher(user);
            var hashedPassword = hasher.VerifyPasswordMatch(password);

            if (!hashedPassword)
                return null;

            return await _ctx.UserProfiles
                .Where(up => up.UserId == user.UserId)
                .Include(up => up.User)
                .Include(up => up.Wrinks)
                .FirstOrDefaultAsync();

        }

        public async Task<User> SignUp(string username, string password, string email)
        {
            var user = new User
            {
                Username = username.ToLower(),
                Email = email
            };

            var checkUsername = await _ctx.Users
                .Where(u => u.Username == username.ToLower())
                .FirstOrDefaultAsync();

            if (!(checkUsername == null))
                return null;

            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();

            var hasher = new PasswordHasher(user);
            user.Password = hasher.HashPassword(password);

            _ctx.Users.Update(user);
            _ctx.UserProfiles.Add(UserProfile.CreateUserProfile(user));
            await _ctx.SaveChangesAsync();

            return user;

        }
    }
}
