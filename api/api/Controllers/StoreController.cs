using api.Dto;
using api.Helpers;
using api.IData;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
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
                return BadRequest("Failed to fetch products " + ex.Message);
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
                return BadRequest("Failed to fetch the orders. " + ex.Message);
            }
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
        {
            if (product == null)
                return NotFound();

            try
            {
                var savedProduct = await _repo.AddProduct(product);

                if (savedProduct == null)
                    return BadRequest("Failed to save the product.");

                return Ok(savedProduct);
            } catch(Exception ex)
            {
                return BadRequest("Failed to save the product. " + ex.Message);
            }
        }

        [HttpPost("add-order")]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            if (order == null)
                return NotFound();

            try
            {
                var savedOrder = await _repo.AddOrder(order);

                if (savedOrder == null)
                    return BadRequest("Failed to save order.");

                return Ok("Order saved successfully");
            } catch(Exception ex)
            {
                return BadRequest("Failed to save order. " + ex.Message);
            }
        }

        [HttpPost("add-review")]
        public async Task<IActionResult> AddReview([FromBody] ReviewDto review)
        {
            try
            {
                if (await _repo.AddAReview(review))
                    return Ok("Review saved successfully.");

                return BadRequest("Failed to save the review.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to save the review. " + ex.Message);
            }
        }

        [HttpPatch("update-product")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest("No product to update.");

            try
            {
                var updatedProduct = await _repo.UpdateProduct(product);

                if (updatedProduct == null)
                    return BadRequest("Failed to update the product.");

                return Ok(updatedProduct);
            } catch (Exception ex)
            {
                return BadRequest("Failed to update the product. " + ex.Message);
            }
        }

        [HttpPut("toggle-product-favorite-status")]
        public async Task<IActionResult> MarkProductFavourite([FromBody]UserFavorite userFavorite)
        {
            if (await _repo.GetProduct(userFavorite.ProductId) == null)
                return BadRequest("This product does not exist.");

            try
            {
                var markedProduct = await _repo.ToggleProductFavoriteStatus(userFavorite);

                if (markedProduct == false)
                    return BadRequest("Failed to update the product.");

                return Ok("Product marked.");
            } catch(Exception ex)
            {
                return BadRequest("Failed to update the product. " + ex.Message);
            }
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct(String id)
        {
            // update product delete
            var product = await _repo.GetProduct(int.Parse(id));

            if (product == null)
                return BadRequest("No product to delete.");

            try
            {
                var updatedProduct = await _repo.DeleteProduct(product);

                if (!updatedProduct)
                    return BadRequest("Failed to update the product.");

                return Ok("Product successfully deleted");
            } catch (Exception ex)
            {
                return BadRequest("Failed to update the product. " + ex.Message);
            }
        }
    }
}
