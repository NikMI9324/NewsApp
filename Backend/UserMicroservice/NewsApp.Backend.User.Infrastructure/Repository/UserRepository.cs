
using Microsoft.EntityFrameworkCore;
using NewsApp.Backend.User.Domain.Interfaces;
using NewsApp.Backend.User.Domain.Models;
using NewsApp.Backend.User.Infrastructure.Data;

namespace NewsApp.Backend.User.Infrastructure.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;
        UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<bool> Exists(string email)
        {
            return await _userDbContext.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<UserModel> GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));

            return await _userDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task Insert(UserModel user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            await _userDbContext.Users.AddAsync(user);
            await _userDbContext.SaveChangesAsync();
        }
    }
}
