using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace OnlineShop.Configuration
{
    public class KupacConfiguration : IEntityTypeConfiguration<Kupac>
    {
        public void Configure(EntityTypeBuilder<Kupac> builder)
        {
            builder.HasKey(u => u.KorisnickoIme);
            builder.Property(u => u.KorisnickoIme).IsRequired();
            builder.HasIndex(u => u.KorisnickoIme).IsUnique();
            builder.Property(u => u.ImeIPrezime).IsRequired().HasMaxLength(50);
            builder.Property(u => u.DatumRodjenja).IsRequired();
            builder.Property(u => u.Adresa).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Lozinka).IsRequired().HasMaxLength(50);

            builder.HasMany(c => c.Porudzbine)
                .WithOne(o => o.Kupac)
                .HasForeignKey(o => o.KorisnickoImeKupca)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Administrator)
                .WithMany(c => c.Kupci)
                .HasForeignKey(c => c.KorisnickoIme)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
