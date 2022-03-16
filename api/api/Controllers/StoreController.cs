using api.Dto;
using api.IData;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _repo;
        private readonly IConfiguration _config;
        public StoreController(IStoreRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpGet("get-products/{userId}")]
        public async Task<IActionResult> GetProducts(string userId)
        {
            try
            {
                var productList = await _repo.GetProducts(userId);

                return Ok(productList);
            } catch (Exception ex)
            {
                return BadRequest("Failed to fetch products");
            }
        }

        [HttpGet("get-orders/{userId}")]
        public async Task<IActionResult> GetOrders(string userId)
        {
            try
            {
                var orderList = await _repo.GetOrders(userId);

                return Ok(orderList);
            } catch (Exception ex)
            {
                return BadRequest("Failed to fetch the orders.");
            }
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
        {
            if (product == null)
                return NotFound();

            var savedProduct = await _repo.AddProduct(product);

            if (savedProduct == null)
                return BadRequest("Failed to save the product.");

            return Ok(savedProduct);
        }

        [HttpPost("add-order")]
        public async Task<IActionResult> Addorder([FromBody] Order order)
        {
            if (order == null)
                return NotFound();

            var savedOrder = await _repo.AddOrder(order);

            if (savedOrder == null)
                return BadRequest("Failed to save order.");

            return Ok("Order saved successfully");
        }

        [HttpPatch("update-product")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest("No product to update.");

            var updatedProduct = await _repo.UpdateProduct(product);

            if (updatedProduct == null)
                return BadRequest("Failed to update the product.");

            return Ok(updatedProduct);
        }

        [HttpPut("toggle-product-favorite-status")]
        public async Task<IActionResult> MarkProductFavourite([FromBody]UserFavorite userFavorite)
        {
            if (await _repo.GetProduct(userFavorite.ProductId.ToString()) == null)
                return BadRequest("This product does not exist.");

            var markedProduct = await _repo.ToggleProductFavoriteStatus(userFavorite);

            if (markedProduct == false)
                return BadRequest("Failed to update the product.");

            return Ok("Product marked.");
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct(String id)
        {
            // update product delete
            var product = await _repo.GetProduct(id);

            if (product == null)
                return BadRequest("No product to delete.");

            var updatedProduct = await _repo.DeleteProduct(product);

            if (!updatedProduct)
                return BadRequest("Failed to update the product.");

            return Ok("Product successfully deleted");
        }
    }
}
