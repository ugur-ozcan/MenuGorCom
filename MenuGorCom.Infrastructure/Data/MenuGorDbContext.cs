// MenuGorDbContext.cs
// File: MenuGorCom.Infrastructure/Data/MenuGorDbContext.cs

using Microsoft.EntityFrameworkCore;
 using MenuGorCom.Core.Entities;
using Serilog;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MenuGorCom.Infrastructure.Data
{
    public class MenuGorDbContext : DbContext
    {
        public MenuGorDbContext(DbContextOptions<MenuGorDbContext> options) : base(options)
        {
        }

        // DbSet tanımlamaları
        public DbSet<Admin> Admins { get; set; }
        //public DbSet<Company> Companies { get; set; }
        //public DbSet<Branch> Branches { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Genel yapılandırmalar
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.ClrType.Name;
                modelBuilder.Entity(entityType.ClrType).ToTable(tableName);
            }

            // Admin yapılandırması
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admins");
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Username).IsRequired().HasMaxLength(50);
                entity.Property(a => a.Email).IsRequired().HasMaxLength(100);
                entity.Property(a => a.PasswordHash).IsRequired();
            });

            //// Diğer entity yapılandırmaları
            //modelBuilder.Entity<Company>(entity =>
            //{
            //    entity.ToTable("Companies");
            //    entity.HasKey(c => c.Id);
            //    entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            //});

            //modelBuilder.Entity<Branch>(entity =>
            //{
            //    entity.ToTable("Branches");
            //    entity.HasKey(b => b.Id);
            //    entity.Property(b => b.Name).IsRequired().HasMaxLength(100);
            //});

            //modelBuilder.Entity<Category>(entity =>
            //{
            //    entity.ToTable("Categories");
            //    entity.HasKey(c => c.Id);
            //    entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
            //});

            //modelBuilder.Entity<Product>(entity =>
            //{
            //    entity.ToTable("Products");
            //    entity.HasKey(p => p.Id);
            //    entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            //});

            //modelBuilder.Entity<Log>(entity =>
            //{
            //    entity.ToTable("Logs");
            //    entity.HasKey(l => l.Id);
            //    entity.Property(l => l.Message).IsRequired();
            //    entity.Property(l => l.CreatedAt).HasDefaultValueSql("GETDATE()");
            //});
        }
    }
}
