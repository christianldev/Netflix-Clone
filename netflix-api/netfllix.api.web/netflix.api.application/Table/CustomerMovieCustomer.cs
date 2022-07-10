using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace netflix.api.application.Table
{
    public partial class CustomerMovieCustomer
    {
        public int CustomerMovieIdCustomer { get; set; }
        public int CustomerCustomerId { get; set; }

        public virtual Customer CustomerCustomer { get; set; }
        public virtual CustomerMovie CustomerMovieIdCustomerNavigation { get; set; }
    }
}
