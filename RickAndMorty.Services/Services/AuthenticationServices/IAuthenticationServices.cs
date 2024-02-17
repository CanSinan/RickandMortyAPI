using RickAndMorty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.AuthenticationServices
{
    public interface IAuthenticationServices : IGenericRepository<User>
    {
        Task<User> RegisterAsync(User user);
        Task<User> LoginAsync(User user);
    }
}
