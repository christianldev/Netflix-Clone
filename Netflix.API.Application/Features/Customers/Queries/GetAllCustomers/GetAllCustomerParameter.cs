using Netflix.API.Application.Parameters;

namespace Netflix.API.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomerParameter :  RequestParameter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
