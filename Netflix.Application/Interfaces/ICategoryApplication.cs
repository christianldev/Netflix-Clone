using Netflix.Application.Commons.Bases;
using Netflix.Application.Dtos.Category.Request;
using Netflix.Application.Dtos.Category.Response;
using Netflix.Infraestructure.Commons.Bases.Request;
using Netflix.Infraestructure.Commons.Bases.Response;

namespace Netflix.Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories();
        Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId);
        Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto);
        Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveCategory(int categoryId);
    }
}