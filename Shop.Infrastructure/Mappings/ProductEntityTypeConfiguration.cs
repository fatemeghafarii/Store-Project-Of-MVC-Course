using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Model.Models;
using System.Data;

namespace Shop.Infrastructure.Mappings
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name)
                .HasMaxLength(512)
                .IsRequired()
                .HasColumnType<string>(nameof(SqlDbType.NVarChar));

            builder.Property(p => p.Description)
               .HasMaxLength(2048)
               .IsRequired()
               .HasColumnType<string>(nameof(SqlDbType.NVarChar));
        }
    }
}
