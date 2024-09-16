namespace StacyStore.Services;

using Models;

public interface IProductService {
    // List methods in ProductService
    Task<List<Product?>> GetAllProducts();
    Task<Product?> GetProductById(Guid id);
    Task<Product> AddProductAsync(Product product);
    Task<Product?> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(Guid id);
}
