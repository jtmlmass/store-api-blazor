namespace StacyStore.Services;

using Data;
using Microsoft.EntityFrameworkCore;
using Models;

public class ProductService : IProductService {
    // The ApplicationDbContext is injected into the ProductService
    readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context) {
        _context = context;
    }

    // The GetAllProducts method returns a list of all products
    public async Task<List<Product?>> GetAllProducts() => await _context.Products.ToListAsync();

    // The GetProductById method returns a single product by its Id
    // The ? operator can be used to indicate that the return type can be null
    public async Task<Product?> GetProductById(Guid id) => await _context.Products.FindAsync(id);

    // The AddProductAsync method adds a new product to the database
    public async Task<Product> AddProductAsync(Product product) {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    // The UpdateProductAsync method updates an existing product in the database
    public async Task<Product?> UpdateProductAsync(Product product) {
        var existingProduct = await _context.Products.FindAsync(product.Id);
        if (existingProduct == null) return existingProduct;

        _context.Entry(existingProduct).CurrentValues.SetValues(product);
        await _context.SaveChangesAsync();
        return existingProduct;
    }

    // The DeleteProductAsync method deletes a product from the database
    public async Task<bool> DeleteProductAsync(Guid id) {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}
