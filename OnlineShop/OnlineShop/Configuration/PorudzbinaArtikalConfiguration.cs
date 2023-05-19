using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace OnlineShop.Configuration
{
    public class PorudzbinaArtikalConfiguration : IEntityTypeConfiguration<PorudzbinaArtikal>
    {
        public void Configure(EntityTypeBuilder<PorudzbinaArtikal> builder)
        {
            builder.HasKey(pa => new { pa.IdPorudzbine, pa.IdArtikla });

            builder.HasOne(pa => pa.Porudzbina)
                .WithMany(pa => pa.PorudzbinaArtikli)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pa => pa.Artikal)
                .WithMany(pa => pa.PorudzbinaArtikli)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
