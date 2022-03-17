using api.Dto;
using api.IData;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext _context;
        public StoreRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<ProductListDto>> GetProducts(string username)
        {
            List<ProductListDto> productListDtos = new List<ProductListDto>();
            var products = await _context.product.Include(r => r.Reviews).ToListAsync();

            foreach(var product in products)
            {
                var userProduct = await _context.userFavorite
                    .Where(p => p.ProductId == product.Id)
                    .Where(u => u.Username == username).FirstOrDefaultAsync();
                var allowReview = await AllowReview(username, product);

                var tempProduct = new ProductListDto()
                {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Reviews = product.Reviews,
                    IsFavorite = userProduct == null ? false : userProduct.IsFavorite,
                    AllowReview = allowReview
                };
                productListDtos.Add(tempProduct);
            }

            return productListDtos;
        }

        public async Task<List<Order>> GetOrders(string username)
        {
            return await _context.order.Select(o => new Order()
            {
                Id = o.Id,
                Amount = o.Amount,
                CreatedAt = o.CreatedAt,
                Products = o.Products.ToList(),
                Username = o.Username,
                User = o.User
            }).Where(o => o.Username == username).ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.product.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Product> AddProduct(Product product)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Product> created =  await _context.product.AddAsync(product);

            if (await SaveAll())
            {
                var prod = new Product()
                {
                    Id = created.Entity.Id,
                    Title = created.Entity.Title,
                    Description = created.Entity.Description,
                    Price = created.Entity.Price,
                    ImageUrl = created.Entity.ImageUrl
                };

                return prod;
            }

            return null;
        }
        public async Task<Order> AddOrder(Order order)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Order> created = await _context.order.AddAsync(order);

            try
            {
                if (await SaveAll())
                {
                    if (order.Products != null)
                    {
                        foreach (var cartItem in order.Products)
                        {
                            cartItem.OrderId = created.Entity.Id;

                            await AddCartItem(cartItem);
                        }
                    }

                    return order;
                }
            } catch(Exception ex)
            {
                return null;
            }

            return null;
        }
        public async Task<User> GetUser(string username)
        {
            return await _context.user.FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<bool> AddCartItem(Cart cartProducts)
        {
            await _context.cart.AddAsync(cartProducts);
            return await SaveAll();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.product.Update(product);
            
            if (await SaveAll())
            {
                return await _context.product.FirstOrDefaultAsync(p => p.Id == product.Id);
            }
            return null;
        }

        public async Task<bool> ToggleProductFavoriteStatus(UserFavorite userFavorite)
        {
            var favorites = await _context.userFavorite.FirstOrDefaultAsync(x => x.Username == userFavorite.Username && x.ProductId == userFavorite.ProductId);

            if (favorites == null)
            {
                await _context.userFavorite.AddAsync(userFavorite);
            } else {
                favorites.IsFavorite = userFavorite.IsFavorite;
                _context.userFavorite.Update(favorites);
            }
            
            return await SaveAll();
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            _context.product.Remove(product);

            return await SaveAll();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        #region
        // Private methods

        private async Task<bool> CheckUserProductInOrders(string username, string productTitle)
        {
            var orders = await GetOrders(username);

            foreach (var products in orders)
            {
                foreach (var product in products.Products)
                {
                    if (product.Title == productTitle)
                        return true;
                }
            }

            return false;
        }

        private async Task<bool> AllowReview(string username, Product product)
        {
            var review = await CheckUserProductInOrders(username, product.Title);

            foreach (var reviews in product.Reviews)
            {
                if (reviews.Username == username)
                    review = false;
            }

            return review;
        }

        #endregion
    }
}
