using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace netflix.api.application.Table
{
    public partial class Address
    {
        public Address()
        {
            Customer = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public int IdCountries { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
