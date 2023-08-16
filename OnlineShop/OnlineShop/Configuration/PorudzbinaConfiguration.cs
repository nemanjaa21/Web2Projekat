using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Models;

namespace OnlineShop.Configuration
{
    public class PorudzbinaConfiguration : IEntityTypeConfiguration<Porudzbina>
    {
        public void Configure(EntityTypeBuilder<Porudzbina> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Adresa).IsRequired();
            builder.Property(p => p.Status).HasConversion(new EnumToStringConverter<Status>());

            builder.HasOne(p => p.Korisnik)
                .WithMany(p => p.Porudzbine)
                .HasForeignKey(p => p.IdKorisnika)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
