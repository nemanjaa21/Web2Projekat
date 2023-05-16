using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace OnlineShop.Configuration
{
    public class PorudzbinaArtikalConfiguration : IEntityTypeConfiguration<PorudzbinaArtikal>
    {
        public void Configure(EntityTypeBuilder<PorudzbinaArtikal> builder)
        {
            builder.HasKey(op => new { op.IdPorudzbine, op.IdArtikla });

            builder.HasOne(p => p.Porudzbina)
                .WithMany(p => p.PorudzbinaArtikli)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Artikal)
                .WithMany(p => p.PorudzbinaArtikli)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
