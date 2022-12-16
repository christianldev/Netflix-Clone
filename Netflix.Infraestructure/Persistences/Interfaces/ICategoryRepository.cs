using Netflix.Domain.Entities;
using Netflix.Infraestructure.Commons.Bases.Request;
using Netflix.Infraestructure.Commons.Bases.Response;

namespace Netflix.Infraestructure.Persistences.Interfaces
{
    public interface ICategoryRepository
    {
        Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters);
        Task<IEnumerable<Category>> ListSelectCategories();
        Task<Category> CategoryById(int categoryId);
        Task<bool> RegisterCategory(Category category);
        Task<bool> EditCategory(Category category);
        Task<bool> RemoveCategory(int categoryId);
    }
}