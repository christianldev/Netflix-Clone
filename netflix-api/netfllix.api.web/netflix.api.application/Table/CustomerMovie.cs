using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace netflix.api.application.Table
{
    public partial class CustomerMovie
    {
        public CustomerMovie()
        {
            CustomerMovieCustomer = new HashSet<CustomerMovieCustomer>();
            CustomerMovieMovie = new HashSet<CustomerMovieMovie>();
        }

        public int Id { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdMovie { get; set; }

        public virtual ICollection<CustomerMovieCustomer> CustomerMovieCustomer { get; set; }
        public virtual ICollection<CustomerMovieMovie> CustomerMovieMovie { get; set; }
    }
}
