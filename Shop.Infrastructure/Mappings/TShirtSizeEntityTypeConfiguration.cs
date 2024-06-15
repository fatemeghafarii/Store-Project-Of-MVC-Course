using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Model.Models;
using System.Data;

namespace Shop.Infrastructure.Mappings
{
    public class TShirtSizeEntityTypeConfiguration : IEntityTypeConfiguration<TShirtSize>
    {
        public void Configure(EntityTypeBuilder<TShirtSize> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(p => p.Name)
                .HasMaxLength(512)
                .IsRequired()
                .HasColumnType<string>(nameof(SqlDbType.NVarChar));
        }
    }


}
