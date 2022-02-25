using System.Linq;
using System.Reflection;
using Core.Models;
using Core.Models.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Order>()
            .Property(o => o.Subtotal)
            .HasColumnType("decimal(18,2)");

        if (Database.ProviderName == "Microsoft.EntityFrameworkCore.SqlServer")
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var propierties = entityType.ClrType.GetProperties().Where(p => p.PropertyType
                    == typeof(decimal));
                foreach (var propierty in propierties)
                    modelBuilder.Entity(entityType.Name).Property(propierty.Name)
                        .HasConversion<double>();
            }
    }
}