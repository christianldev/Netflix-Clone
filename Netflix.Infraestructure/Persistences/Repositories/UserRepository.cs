using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Entities;
using Netflix.Infraestructure.Persistences.Context;
using Netflix.Infraestructure.Persistences.Interfaces;

namespace Netflix.Infraestructure.Persistences.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly NetflixApiContext _context;
        public UserRepository(NetflixApiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> AccountByEmail(string email)
        {
            var account = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email!.Equals(email));
            return account!;
        }
    }
}