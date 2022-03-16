using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Order has one to many cart items which they have a cartId.
            builder.Entity<Cart>().HasOne(x => x.Orders).WithMany(x => x.Products).HasForeignKey(x => x.OrderId);
            builder.Entity<UserFavorite>().HasOne(x => x.Users).WithMany(x => x.Favorites).HasForeignKey(x => x.Username);
            builder.Entity<Order>().HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.Username);
        }
        public DbSet<User> user { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<UserFavorite> UserFavorite { get; set; }
    }
}
