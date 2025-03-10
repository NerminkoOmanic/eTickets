﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eTicketsAPI.Database
{
    public partial class Uloga
    {
        public Uloga()
        {
            Korisnik = new HashSet<Korisnik>();
        }

        public int UlogaId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}
