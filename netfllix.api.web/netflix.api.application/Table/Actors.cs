using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace netflix.api.application.Table
{
    public partial class Actors
    {
        public Actors()
        {
            Movie = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
