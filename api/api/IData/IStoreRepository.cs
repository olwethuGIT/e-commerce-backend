using api.Dto;
using api.Models;

namespace api.IData
{
    public interface IStoreRepository
    {
        Task<List<ProductListDto>> GetProducts(string username);
        Task<List<Order>> GetOrders(string username);
        Task<Product> GetProduct(int id);
        Task<User> GetUser(string username);
        Task<Product> AddProduct(Product product);
        Task<Order> AddOrder(Order order);
        Task<bool> AddCartItem(Cart cartProducts);
        Task<Product> UpdateProduct(Product product);
        Task<bool> ToggleProductFavoriteStatus(UserFavorite userFavorite);
        Task<bool> DeleteProduct(Product product);
        Task<bool> SaveAll();
    }
}
