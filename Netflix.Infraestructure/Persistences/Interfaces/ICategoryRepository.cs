using Netflix.Domain.Entities;
using Netflix.Infraestructure.Commons.Bases.Request;
using Netflix.Infraestructure.Commons.Bases.Response;

namespace Netflix.Infraestructure.Persistences.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters);

    }
}