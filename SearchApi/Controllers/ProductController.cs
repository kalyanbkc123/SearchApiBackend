

using SearchApi.Models;
using SearchApi.Repositories;
using SearchApi.Services;

namespace SearchApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return Ok(await _service.GetAllProductsAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        
        }
        

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            await _service.AddProductAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        /*

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            await _service.UpdateProductAsync(product);
            return NoContent();
        }

        */
        /*

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteProductAsync(id);
            return NoContent();
        }

        */
        /*
        [HttpGet("search-by-title")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByTitle([FromQuery] string title)
        {
            var products = await _service.GetProductsByTitleAsync(title);

            if (products == null || !products.Any())
            {
                return NotFound("No products found with the given title.");
            }

            return Ok(products);
        }
        */

        /*
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByTitleOrDescription([FromQuery] string searchTerm)
        {
            var products = await _service.GetProductsByTitleOrFeaturesAsync(searchTerm);

            if (products == null || !products.Any())
            {
                return NotFound("No products found with the given search term.");
            }

            return Ok(products);
        }
        */

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByMultipleSearchTerms([FromQuery] string searchTerm)
        {
            // Split the search term by space or another delimiter
            var searchTerms = searchTerm.Split(' ');

            // Call the service to get products by search terms
            var products = await _service.GetProductsByMultipleSearchTermsAsync(searchTerms);

            if (products == null || !products.Any())
            {
                return NotFound("No products found with the given search terms.");
            }

            return Ok(products);
        }



    }

}



