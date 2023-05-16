using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace OnlineShop.Configuration
{
    public class PorudzbinaConfiguration : IEntityTypeConfiguration<Porudzbina>
    {
        public void Configure(EntityTypeBuilder<Porudzbina> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Adresa).IsRequired();
        }
    }
}
