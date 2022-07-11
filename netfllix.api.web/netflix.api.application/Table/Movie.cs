using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace netflix.api.application.Table
{
    public partial class Movie
    {
        public Movie()
        {
            CustomerMovieMovie = new HashSet<CustomerMovieMovie>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DateMovie { get; set; }
        public string Url { get; set; }
        public int? IdGenre { get; set; }
        public int? IdActor { get; set; }
        public int? IdDirector { get; set; }

        public virtual Actors IdActorNavigation { get; set; }
        public virtual Director IdDirectorNavigation { get; set; }
        public virtual Genres Genres { get; set; }
        public virtual ICollection<CustomerMovieMovie> CustomerMovieMovie { get; set; }
    }
}
