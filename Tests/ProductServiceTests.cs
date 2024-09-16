namespace StacyStore.Tests;

using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;
using Xunit;

public class ProductServiceTests {
    readonly ApplicationDbContext _context;
    readonly IProductService _service;

    public ProductServiceTests() {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        _context = new ApplicationDbContext(options);
        _service = new ProductService(_context);
    }

    [Fact] public async Task CreateAsync_ShouldAddProduct() {
        var product = new Product { Name = "Test Product", Price = 100.00m, Category = Category.Electronics };
        var result = await _service.AddProductAsync(product);

        Assert.NotNull(result);
        Assert.Equal(product.Name, result.Name);
    }

    [Fact] public async Task UpdateAsync_ShouldUpdateProduct() {
        var product = new Product { Name = "Test Product", Price = 100.00m, Category = Category.Electronics };
        var createdProduct = await _service.AddProductAsync(product);

        createdProduct.Name = "Updated Product";
        var result = await _service.UpdateProductAsync(createdProduct);

        Assert.NotNull(result);
        Assert.Equal("Updated Product", result?.Name);
    }
}
