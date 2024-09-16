namespace StacyStore.Tests;

using Controllers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using Services;
using Xunit;

public class ProductControllerTests {
    readonly ProductController _controller;
    readonly Mock<IProductService> _mockService;

    public ProductControllerTests() {
        _mockService = new Mock<IProductService>();
        _controller = new ProductController(_mockService.Object);
    }

    [Fact] public async Task CreateProduct_ShouldReturnCreatedProduct() {
        var product = new Product { Name = "Test Product", Price = 100.00m, Category = Category.Electronics };
        _mockService.Setup(s => s.AddProductAsync(product)).ReturnsAsync(product);

        var result = await _controller.AddProduct(product);

        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnValue = Assert.IsType<Product>(createdAtActionResult.Value);
        Assert.Equal(product.Name, returnValue.Name);
    }

    [Fact] public async Task UpdateProduct_ShouldReturnUpdatedProduct() {
        var product = new Product { Id = Guid.NewGuid(), Name = "Test Product", Price = 100.00m, Category = Category.Electronics };
        _mockService.Setup(s => s.UpdateProductAsync(product)).ReturnsAsync(product);

        var result = await _controller.UpdateProduct(product);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Product>(okResult.Value);
        Assert.Equal(product.Name, returnValue.Name);
    }
}
