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
        public DbSet<Porudzbina> Porudzbine { get; set; }
        public DbSet<Artikal> Artikli { get; set; }
        public DbSet<PorudzbinaArtikal> PorudzbineArtikli { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
