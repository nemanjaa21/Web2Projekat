using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace OnlineShop.Configuration
{
    public class KorisnikConfiguration : IEntityTypeConfiguration<Korisnik>
    {
        public void Configure(EntityTypeBuilder<Korisnik> builder)
        {
            builder.HasKey(k => k.IdKorisnika);
            builder.Property(k => k.IdKorisnika).ValueGeneratedOnAdd();
            builder.Property(k => k.KorisnickoIme).IsRequired();
            builder.HasIndex(k => k.KorisnickoIme).IsUnique();
            builder.Property(k => k.Email).IsRequired();
            builder.Property(k => k.Lozinka).IsRequired().HasMaxLength(50);
            builder.Property(k => k.ImeIPrezime).IsRequired().HasMaxLength(50);
            builder.Property(k => k.DatumRodjenja).IsRequired();
        }
    }
}
