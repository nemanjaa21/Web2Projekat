using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Configuration
{
    public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.HasKey(u => u.KorisnickoIme);
            builder.Property(u => u.KorisnickoIme).IsRequired();
            builder.HasIndex(u => u.KorisnickoIme).IsUnique();
            builder.Property(u => u.ImeIPrezime).IsRequired().HasMaxLength(50);
            builder.Property(u => u.DatumRodjenja).IsRequired();
            builder.Property(u => u.Adresa).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Lozinka).IsRequired().HasMaxLength(50);
        }
    }
}
