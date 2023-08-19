using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Models;

namespace OnlineShop.Configuration
{
    public class KorisnikConfiguration : IEntityTypeConfiguration<Korisnik>
    {
        public void Configure(EntityTypeBuilder<Korisnik> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).ValueGeneratedOnAdd();
            builder.Property(k => k.KorisnickoIme).IsRequired();
            builder.HasIndex(k => k.KorisnickoIme).IsUnique();
            builder.Property(k => k.Email).IsRequired();
            builder.Property(k => k.Lozinka).IsRequired();
            builder.Property(k => k.Ime).IsRequired().HasMaxLength(50);
            builder.Property(k => k.Prezime).IsRequired().HasMaxLength(50);
            builder.Property(k => k.DatumRodjenja).IsRequired();
            builder.Property(k => k.Adresa).IsRequired();
            builder.Property(k => k.TipKorisnika).HasConversion(
                new EnumToStringConverter<TipKorisnika>());
            builder.Property(k => k.Verifikovan).HasConversion(
                new EnumToStringConverter<Verifikovan>());
        }
    }
}
