using RickAndMorty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.AuthenticationRepositories
{
    public interface IAuthenticationRepository : IGenericRepository<User>
    {
        Task<User> RegisterAsync(User user);
        Task<User> LoginAsync(User user);
        Task SaveAsync();
    }
}
