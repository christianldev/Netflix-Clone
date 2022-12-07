using Ardalis.Specification.EntityFrameworkCore;
using Netflix.API.Application.Interfaces;
using Netflix.API.Persistence.Contexts;

namespace Netflix.API.Persistence.Repository
{
    public class MyRepositoryAsync<T> : RepositoryBase<T>,IRepositoryAsync<T>,IReadRepositoryAsync<T> where T :class
    {
        public readonly AppBankDbContext dbContext;

        public MyRepositoryAsync(AppBankDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
