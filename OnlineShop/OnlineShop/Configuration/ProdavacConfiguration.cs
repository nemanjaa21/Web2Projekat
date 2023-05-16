using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace OnlineShop.Configuration
{
    public class ProdavacConfiguration : IEntityTypeConfiguration<Prodavac>
    {
        public void Configure(EntityTypeBuilder<Prodavac> builder)
        {
            builder.HasKey(u => u.KorisnickoIme);
            builder.Property(u => u.KorisnickoIme).IsRequired();
            builder.HasIndex(u => u.KorisnickoIme).IsUnique();
            builder.Property(u => u.ImeIPrezime).IsRequired().HasMaxLength(50);
            builder.Property(u => u.DatumRodjenja).IsRequired();
            builder.Property(u => u.Adresa).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Lozinka).IsRequired().HasMaxLength(50);

            builder.HasOne(s => s.Administrator)
                .WithMany(s=> s.Prodavci)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.Artikli)
                .WithOne(p => p.Prodavac)
                .HasForeignKey(p => p.KorisnickoImeProdavca)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
