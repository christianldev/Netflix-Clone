using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Netflix.Application.Commons.Bases;
using Netflix.Application.Dtos.Request;
using Netflix.Application.Dtos.Response;
using Netflix.Application.Interfaces;
using Netflix.Application.Validators.Category;
using Netflix.Infraestructure.Commons.Bases.Request;
using Netflix.Infraestructure.Commons.Bases.Response;
using Netflix.Infraestructure.Persistences.Interfaces;

namespace Netflix.Application.Services
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CategoryValidator _categoryValidator;

        public CategoryApplication(IUnitOfWork unitOfWork, IMapper mapper, CategoryValidator categoryValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryValidator = categoryValidator;
        }
        public Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFiltersRequest filters)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }


        public Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto)
        {
            throw new NotImplementedException();
        }


        public Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> RemoveCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}