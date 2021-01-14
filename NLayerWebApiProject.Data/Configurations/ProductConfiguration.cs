using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerWebApiProject.Core.Models;

namespace NLayerWebApiProject.Data.Configurations
{
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

            builder.Property(p => p.Name)
                        .IsRequired()
                        .HasMaxLength(200);
            
            builder.Property(p => p.Stock)
                        .IsRequired();
            
            builder.Property(p => p.Price)
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

            builder.Property(p => p.InnerBarcode)
                        .HasMaxLength(50);

            builder.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId);

        }
    }
}