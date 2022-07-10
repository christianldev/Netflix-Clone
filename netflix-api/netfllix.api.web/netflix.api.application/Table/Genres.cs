﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace netflix.api.application.Table
{
    public partial class Genres
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public byte[] CreatedAt { get; set; }

        public virtual Movie IdNavigation { get; set; }
    }
}