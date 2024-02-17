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
            var userValidate = await _context.Users.Include(x=>x.UserRole).FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Password == user.Password);
            if (userValidate is null)
            {
                return null;
            }
            return userValidate;
        }

        public async Task<User> RegisterAsync(User user)
        {
            var userExist = _context.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName);
            if (userExist is not null)
            {
                return null;

            }
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
