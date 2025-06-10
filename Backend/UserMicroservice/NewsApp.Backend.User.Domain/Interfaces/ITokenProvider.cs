using NewsApp.Backend.User.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Backend.User.Domain.Interfaces
{
    public interface ITokenProvider
    {
        string CreateToken(UserModel user);
    }
}
