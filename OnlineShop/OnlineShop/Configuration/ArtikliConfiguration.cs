using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace OnlineShop.Configuration
{
    public class ArtikliConfiguration : IEntityTypeConfiguration<Artikal>
    {
        public void Configure(EntityTypeBuilder<Artikal> builder)
        {
            builder.HasKey(p => p.IDArtikla);
            builder.Property(p => p.Naziv).IsRequired();
            builder.Property(p => p.Cena).IsRequired();
            builder.Property(p => p.Kolicina).IsRequired();
        }
    }
}
