using Microsoft.EntityFrameworkCore;
using SkinetMarket.Models;

namespace SkinetMarket.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
