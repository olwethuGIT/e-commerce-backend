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
            var products = await _context.Product.ToListAsync();

            foreach(var product in products)
            {
                var userProduct = await _context.UserFavorite
                    .Where(p => p.ProductId == product.Id)
                    .Where(u => u.Username == username).FirstOrDefaultAsync();

                var tempProduct = new ProductListDto()
                {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    IsFavorite = userProduct == null ? false : userProduct.IsFavorite
                };
                productListDtos.Add(tempProduct);
            }

            return productListDtos;
        }

        public async Task<List<Order>> GetOrders(string username)
        {
            return await _context.Order.Select(o => new Order()
            {
                Id = o.Id,
                Amount = o.Amount,
                CreatedAt = o.CreatedAt,
                Products = o.Products.ToList(),
                Username = o.Username,
                User = o.User
            }).Where(o => o.Username == username).ToListAsync();
        }
        public async Task<Product?> GetProduct(string id)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.Id == int.Parse(id));
        }
        public async Task<Product?> AddProduct(Product product)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Product> created =  await _context.Product.AddAsync(product);

            if (await _context.SaveChangesAsync() > 0)
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
        public async Task<Order?> AddOrder(Order order)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Order> created = await _context.Order.AddAsync(order);

            try
            {
                if (await _context.SaveChangesAsync() > 0)
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
        public async Task AddCartItem(Cart cartProducts)
        {
            await _context.Cart.AddAsync(cartProducts);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            _context.Product.Update(product);
            
            if (await _context.SaveChangesAsync() > 0)
            {
                return await GetProduct(product.Id.ToString());
            }
            return null;
        }

        public async Task<bool> ToggleProductFavoriteStatus(UserFavorite userFavorite)
        {
            var favorites = await _context.UserFavorite.FirstOrDefaultAsync(x => x.Username == userFavorite.Username && x.ProductId == userFavorite.ProductId);

            if (favorites == null)
            {
                await _context.UserFavorite.AddAsync(userFavorite);
            } else {
                favorites.IsFavorite = userFavorite.IsFavorite;
                _context.UserFavorite.Update(favorites);
            }
            
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            _context.Product.Remove(product);

            if (await _context.SaveChangesAsync() > 0)
                return true;

            return false;
        }
    }
}
