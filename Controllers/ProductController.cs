namespace StacyStore.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class ProductController : ControllerBase {
    readonly IProductService _productService;

    public ProductController(IProductService productService) {
        _productService = productService;
    }

    [HttpGet("{id}")] public async Task<ActionResult<Product>> GetProductById(Guid id) {
        var product = await _productService.GetProductById(id);
        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpGet] public async Task<ActionResult<List<Product?>>> GetAllProducts() => await _productService.GetAllProducts();

    [HttpPost] public async Task<ActionResult<Product>> AddProduct(Product product) {
        var addedProduct = await _productService.AddProductAsync(product);
        return CreatedAtAction(nameof(GetProductById), new { id = addedProduct.Id }, addedProduct);
    }

    [HttpPut] public async Task<ActionResult<Product>> UpdateProduct(Product product) {
        var updatedProduct = await _productService.UpdateProductAsync(product);
        if (updatedProduct == null) return NotFound();

        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")] public async Task<ActionResult> DeleteProduct(Guid id) {
        var result = await _productService.DeleteProductAsync(id);
        if (!result) return NotFound();

        return NoContent();
    }
}
