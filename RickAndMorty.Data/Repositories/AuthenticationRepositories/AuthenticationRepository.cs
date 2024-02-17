using Microsoft.EntityFrameworkCore;
using RickAndMorty.Data.Contexts;
using RickAndMorty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.AuthenticationRepositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly RickAndMortyDbContext _context;

        public AuthenticationRepository(RickAndMortyDbContext context)
        {
            _context = context;
        }

        public async Task<User> LoginAsync(User user)
        {
            var userValidate = await _context.Users.Include(x=>x.Role).FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Password == user.Password);
            if (userValidate is null)
            {
                return null;
            }
            return userValidate;
        }

        public async Task<User> RegisterAsync(User user)
        {
            await _context.Users.AddAsync(user);

            await SaveAsync();
            return user;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
