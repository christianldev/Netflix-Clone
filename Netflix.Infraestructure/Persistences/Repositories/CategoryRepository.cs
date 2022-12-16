using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Netflix.Domain.Entities;
using Netflix.Infraestructure.Persistences.Context;
using Netflix.Infraestructure.Persistences.Interfaces;

namespace Netflix.Infraestructure.Persistences.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly NetflixApiContext _context;

        public CategoryRepository(NetflixApiContext context)
        {
            _context = context;
        }
    }
}