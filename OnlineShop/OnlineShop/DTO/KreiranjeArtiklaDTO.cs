﻿namespace OnlineShop.DTO
{
    public class KreiranjeArtiklaDTO
    {
        public string NazivArtikla { get; set; }
        public int CenaArtikla { get; set; }
        public int Kolicina { get; set; }
        public string Opis { get; set; }
        public byte[]? SlikaArtikla { get; set; }

        //public string SlikaArtikla { get; set; }
    }
}