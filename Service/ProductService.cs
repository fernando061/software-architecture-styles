using Core.Entity;
using Core.Interfaces;

namespace Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        // Lógica de negocio: validar que hay productos disponibles
        var products = await _productRepository.GetAllAsync();
        
        if (!products.Any())
        {
            throw new InvalidOperationException("No products available in the system.");
        }

        return products;
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        // Lógica de negocio: validar ID
        if (id <= 0)
        {
            throw new ArgumentException("Product ID must be greater than 0.");
        }

        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<Product> CreateProductAsync(string name, decimal price)
    {
        // Lógica de negocio: validaciones
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Product name cannot be empty.");
        }

        if (price <= 0)
        {
            throw new ArgumentException("Product price must be greater than 0.");
        }

        if (price > 10000)
        {
            throw new ArgumentException("Product price cannot exceed $10,000.");
        }

        var product = new Product
        {
            Name = name.Trim(),
            Price = price
        };

        return await _productRepository.AddAsync(product);
    }

    public async Task<Product> UpdateProductAsync(int id, string name, decimal price)
    {
        // Lógica de negocio: validaciones
        if (id <= 0)
        {
            throw new ArgumentException("Product ID must be greater than 0.");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Product name cannot be empty.");
        }

        if (price <= 0)
        {
            throw new ArgumentException("Product price must be greater than 0.");
        }

        if (price > 10000)
        {
            throw new ArgumentException("Product price cannot exceed $10,000.");
        }

        var existingProduct = await _productRepository.GetByIdAsync(id);
        if (existingProduct == null)
        {
            throw new ArgumentException($"Product with ID {id} not found.");
        }

        existingProduct.Name = name.Trim();
        existingProduct.Price = price;

        return await _productRepository.UpdateAsync(existingProduct);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        // Lógica de negocio: validar ID
        if (id <= 0)
        {
            throw new ArgumentException("Product ID must be greater than 0.");
        }

        var existingProduct = await _productRepository.GetByIdAsync(id);
        if (existingProduct == null)
        {
            throw new ArgumentException($"Product with ID {id} not found.");
        }

        return await _productRepository.DeleteAsync(id);
    }
} 