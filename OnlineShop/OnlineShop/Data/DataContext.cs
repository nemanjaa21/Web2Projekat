using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Prodavac> Prodavci { get; set; }
        public DbSet<Administrator> Administratori { get; set; }
        public DbSet<Artikal> Artikli { get; set; }
        public DbSet<Porudzbina> Porudzbine { get; set; }
        public DbSet<PorudzbinaArtikal> PorudzbinaArtikli { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between Administrator and Prodavac
            modelBuilder.Entity<Administrator>()
                .HasMany(a => a.Prodavci)
                .WithOne(p => p.Administrator)
                .HasForeignKey(p => p.KorisnickoIme)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship between Administrator and Kupac
            modelBuilder.Entity<Administrator>()
                .HasMany(a => a.Kupci)
                .WithOne(k => k.Administrator)
                .HasForeignKey(k => k.KorisnickoIme)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship between Prodavac and Artikal
            modelBuilder.Entity<Prodavac>()
                .HasMany(p => p.Artikli)
                .WithOne(a => a.Prodavac)
                .HasForeignKey(a => a.KorisnickoIme)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure many-to-many relationship between Porudzbina and Artikal using PorudzbinaArtikal join table
            modelBuilder.Entity<PorudzbinaArtikal>()
                .HasKey(pa => new { pa.IdPorudzbine, pa.IdArtikla });

            modelBuilder.Entity<PorudzbinaArtikal>()
                .HasOne(pa => pa.Porudzbina)
                .WithMany(p => p.PorudzbinaArtikli)
                .HasForeignKey(pa => pa.IdPorudzbine);

            modelBuilder.Entity<PorudzbinaArtikal>()
                .HasOne(pa => pa.Artikal)
                .WithMany(a => a.PorudzbinaArtikli)
                .HasForeignKey(pa => pa.IdArtikla);

            // Configure one-to-many relationship between Porudzbina and Kupac
            modelBuilder.Entity<Porudzbina>()
                .HasOne(p => p.Kupac)
                .WithMany(k => k.Porudzbine)
                .HasForeignKey(p => p.KorisnickoIme)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
