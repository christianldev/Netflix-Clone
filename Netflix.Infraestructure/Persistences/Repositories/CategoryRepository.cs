using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Entities;
using Netflix.Infraestructure.Commons.Bases.Request;
using Netflix.Infraestructure.Commons.Bases.Response;
using Netflix.Infraestructure.Persistences.Context;
using Netflix.Infraestructure.Persistences.Interfaces;
using Netflix.Utilities.Static;

namespace Netflix.Infraestructure.Persistences.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(NetflixApiContext context) : base(context) { }
        public async Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Category>();


            var categories = GetEntityQuery(x => x.AuditDeleteUser == null && x.AuditDeleteDate == null);

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        categories = categories.Where(c => c.Name!.Contains(filters.TextFilter));
                        break;
                    default:
                        break;
                }
            }

            if (filters.StateFilter is not null)
            {
                categories = categories.Where(c => c.State.Equals(filters.StateFilter));
            }

            if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
            {
                categories = categories.Where(c => c.AuditCreateDate >= Convert.ToDateTime(filters.StartDate)
                             && c.AuditCreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
            }

            if (filters.Sort is null) filters.Sort = "Id";

            response.TotalRecords = await categories.CountAsync();
            response.Items = await Ordering(filters, categories, !(bool)filters.Download!).ToListAsync();
            return response;



        }

    }
}