using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryID = 1,ProductName="Kalem 1", Price = 100, Stock = 20, CreatedDate = DateTime.Now },
                new Product { Id = 2, CategoryID = 1, ProductName = "Kalem 2", Price = 100, Stock = 20, CreatedDate = DateTime.Now },
                new Product { Id = 3, CategoryID = 1, ProductName = "Kalem 3", Price = 100, Stock = 20, CreatedDate = DateTime.Now },
                new Product { Id = 4, CategoryID = 2, ProductName = "Kitap 1", Price = 100, Stock = 20, CreatedDate = DateTime.Now },
                new Product { Id = 5, CategoryID = 2, ProductName = "Kitap 2", Price = 100, Stock = 20, CreatedDate = DateTime.Now },
                new Product { Id = 6, CategoryID = 2, ProductName = "Kitap 3", Price = 100, Stock = 20, CreatedDate = DateTime.Now }
                );
        }
    }
}
