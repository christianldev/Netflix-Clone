using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Netflix.Infraestructure.Persistences.Context;
using Netflix.Infraestructure.Persistences.Interfaces;

namespace Netflix.Infraestructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NetflixApiContext _context;
        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(NetflixApiContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}