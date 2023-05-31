﻿using OnlineShop.Models;

namespace OnlineShop.DTO
{
    public class KorisnikDTO
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public byte[]? SlikaKorisnika { get; set; }
        // public string SlikaKorisnika { get; set; }

    }
}
