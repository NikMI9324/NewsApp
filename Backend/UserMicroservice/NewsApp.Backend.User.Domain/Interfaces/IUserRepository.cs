using NewsApp.Backend.User.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Backend.User.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Exists(string email);
        Task Insert(UserModel user);
        Task<UserModel> GetByEmail(string email);
    }
}
