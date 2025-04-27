using HelpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpApp.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);
            builder.Property(p => p.Image).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Stock).IsRequired();
            builder.HasOne(e => e.Category).WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);
            builder.HasData(
                new Product(1, "Lapiseira", "Lapiseira ponteira 0.7", 11.99m, 200, "lapiseira07.png") { CategoryId = 1 },
                new Product(2, "Smartwatch", "Smartwatch 2025", 300.00m, 30, "smartwatch2025.jpg") { CategoryId = 2 },
                new Product(3, "Brinco", "Brinco de prata", 54.99m, 50, "brincoprata.jpg") { CategoryId = 3 },
                new Product(4, "Laranja", "Laranja Pera", 9.99m, 100, "laranjapera.jpg") { CategoryId = 4 },
                new Product(5, "Contra Filé", "Contra Filé Bovino", 49.90m, 15, "contrafile.jpg") { CategoryId = 5 }
                );
        }
    }
}
