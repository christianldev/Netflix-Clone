using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace netflix.api.application.Table
{
    public partial class CustomerMovieMovie
    {
        public int CustomerMovieIdMovie { get; set; }
        public int MovieMovieId { get; set; }

        public virtual CustomerMovie CustomerMovieIdMovieNavigation { get; set; }
        public virtual Movie MovieMovie { get; set; }
    }
}
