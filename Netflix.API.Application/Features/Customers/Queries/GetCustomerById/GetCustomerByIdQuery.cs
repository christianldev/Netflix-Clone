using AutoMapper;
using Netflix.API.Application.DTOS;
using Netflix.API.Application.Interfaces;
using Netflix.API.Application.Wrappers;
using Netflix.API.Domain.Entities;
using MediatR;

namespace Netflix.API.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetCustomerByIdQuery : IRequest<Response<CustomerDTO>>
    {
        public int Id { get; set; }

     
        public class GetAllCustomerQueryHandle : IRequestHandler<GetCustomerByIdQuery, Response<CustomerDTO>>
        {

            private readonly IRepositoryAsync<Customer> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllCustomerQueryHandle(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }
            public async Task<Response<CustomerDTO>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
               var customerBd = await _repositoryAsync.GetByIdAsync(request.Id);

                if (customerBd == null)
                {
                    throw new KeyNotFoundException($"No records found with Id: {request.Id}");
                }

                var customerDto = _mapper.Map<CustomerDTO>(customerBd);
                return new Response<CustomerDTO>(customerDto); 
            }
        }
    }
}
