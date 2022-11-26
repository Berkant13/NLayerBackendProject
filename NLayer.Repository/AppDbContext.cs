using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        //options un bize sağladığı şey startup dosyasında configurations ları yollayıp settingsleri ayarlayabilicez.
        //standart bir constructor dır.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }


        //model oluşurken çalışıcak method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //IEntityTypeConfiguration bu interfaceden türeyen bütün classları bulur ve configuration larını derler.(müthiş birşey )
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
