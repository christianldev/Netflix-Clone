using AutoMapper;
using Netflix.API.Application.DTOS;
using Netflix.API.Application.Features.Customers.Commands.CreateCustomerCommand;
using Netflix.API.Domain.Entities;

namespace Netflix.API.Application.Mappings
{
    public  class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            #region Commands
            CreateMap<CreateCustomerCommand, Customer>();
            #endregion
            #region DTOs
            CreateMap<Customer, CustomerDTO>();
            #endregion
        }
    }
}
