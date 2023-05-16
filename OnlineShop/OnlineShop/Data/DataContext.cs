using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Prodavac> Prodavci { get; set; }
        public DbSet<Administrator> Administratori { get; set; }
        public DbSet<Kupac> Artikli { get; set; }
        public DbSet<Kupac> Porudzbine { get; set; }
        public DbSet<PorudzbinaArtikal> PorudzbinaArtikli { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

    }
}
