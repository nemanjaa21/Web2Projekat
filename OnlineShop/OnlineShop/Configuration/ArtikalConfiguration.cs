using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace OnlineShop.Configuration
{
    public class ArtikalConfiguration : IEntityTypeConfiguration<Artikal>
    {
        public void Configure(EntityTypeBuilder<Artikal> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.NazivArtikla).IsRequired();
            builder.Property(a => a.Kolicina).IsRequired();
            builder.Property(a => a.CenaArtikla).IsRequired();
            builder.Property(a => a.Obrisan).HasDefaultValue(false);

            builder.HasOne(a => a.Korisnik)
                .WithMany(a => a.Artikli)
                .HasForeignKey(a => a.IdKorisnika)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
