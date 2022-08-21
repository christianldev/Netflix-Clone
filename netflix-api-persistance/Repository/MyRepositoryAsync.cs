using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification.EntityFrameworkCore;
using netflix_api_application.Interfaces;
using netflix_api_persistance.Context;

namespace netflix_api_persistance.Repository;

public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
{

    private readonly ApplicationDbContext dbContext;
    public MyRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}
