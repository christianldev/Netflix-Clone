using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Netflix.Infraestructure.Commons.Bases.Request;

namespace Netflix.Infraestructure.Helpers
{
    public static class QueryableHelper
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, BasePaginationRequest paginationRequest)
        {
            return query
                .Skip((paginationRequest.NumPage - 1) * paginationRequest.Records)
                .Take(paginationRequest.Records);
        }
    }
}