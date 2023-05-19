using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace OnlineShop.Configuration
{
    public class PorudzbinaConfiguration : IEntityTypeConfiguration<Porudzbina>
    {
        public void Configure(EntityTypeBuilder<Porudzbina> builder)
        {
            builder.HasKey(p => p.IdPorudzbine);
            builder.Property(p => p.IdPorudzbine).ValueGeneratedOnAdd();
            builder.Property(p => p.Adresa).IsRequired();

            builder.HasOne(p => p.Korisnik)
                .WithMany(p => p.Porudzbine)
                .HasForeignKey(p => p.IdKorisnika)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
