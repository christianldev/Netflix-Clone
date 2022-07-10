using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace netflix.api.application.Table
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerMovieCustomer = new HashSet<CustomerMovieCustomer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int? IdAddress { get; set; }
        public byte? State { get; set; }
        public byte[] CreatedAt { get; set; }

        public virtual Address IdAddressNavigation { get; set; }
        public virtual ICollection<CustomerMovieCustomer> CustomerMovieCustomer { get; set; }
    }
}
