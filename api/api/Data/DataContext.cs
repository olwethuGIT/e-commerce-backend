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

            //
            builder.Entity<UserFavorite>().HasOne(x => x.Users).WithMany(x => x.Favorites).HasForeignKey(x => x.Username);

            //
            builder.Entity<Order>().HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.Username);

            // A product has a one to many relationship with reviews
            builder.Entity<Review>().HasOne(x => x.Products).WithMany(x => x.Reviews).HasForeignKey(x => x.ProductId);

            // A user has a one to many relationship with reviews
            builder.Entity<Review>().HasOne(x => x.Users).WithMany(x => x.Reviews).HasForeignKey(x => x.Username);
        }
        public DbSet<User> user { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<UserFavorite> userFavorite { get; set; }
        public DbSet<Review> review { get; set; }
    }
}
