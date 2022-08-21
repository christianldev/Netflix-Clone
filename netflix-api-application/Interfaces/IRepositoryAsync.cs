using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace netflix_api_application.Interfaces;

public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
{

}

public interface IReadRepositoryAsync<T> : IRepositoryBase<T> where T : class
{

}
