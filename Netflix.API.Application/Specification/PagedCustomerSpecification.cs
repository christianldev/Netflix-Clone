using Ardalis.Specification;
using Netflix.API.Domain.Entities;

namespace Netflix.API.Application.Specification
{
    public class PagedCustomerSpecification : Specification<Customer>
    {
        public PagedCustomerSpecification(int pageSize, int pageNumber, string firstName, string lastName)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(firstName))
            {
                Query.Search(x => x.FirtsName, firstName);
            }

            if (!string.IsNullOrEmpty(firstName))
                Query.Search(x => x.FirtsName, $"%{firstName}$");

            if (!string.IsNullOrEmpty(lastName))
                Query.Search(x => x.LastName, $"%{firstName}$");


        }
    }
}
