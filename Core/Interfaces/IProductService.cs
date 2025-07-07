using Core.Entity;

namespace Core.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(string name, decimal price);
    Task<Product> UpdateProductAsync(int id, string name, decimal price);
    Task<bool> DeleteProductAsync(int id);
} 