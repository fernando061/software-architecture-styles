using Core.Entity;
using Core.Interfaces;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products;
    private int _nextId = 1;

    public ProductRepository()
    {
        _products = new List<Product>();
        // Agregar algunos productos de ejemplo
        SeedData();
    }

    private void SeedData()
    {
        _products.AddRange(new[]
        {
            new Product { Id = _nextId++, Name = "Laptop", Price = 999.99m, CreatedAt = DateTime.Now.AddDays(-5) },
            new Product { Id = _nextId++, Name = "Mouse", Price = 25.50m, CreatedAt = DateTime.Now.AddDays(-3) },
            new Product { Id = _nextId++, Name = "Keyboard", Price = 75.00m, CreatedAt = DateTime.Now.AddDays(-2) }
        });
    }
    
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        await Task.Delay(100); // Simular operación asíncrona
        return _products.ToList();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        await Task.Delay(50); // Simular operación asíncrona
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public async Task<Product> AddAsync(Product product)
    {
        await Task.Delay(100); // Simular operación asíncrona
        product.Id = _nextId++;
        product.CreatedAt = DateTime.Now;
        _products.Add(product);
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        await Task.Delay(100); // Simular operación asíncrona
        var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct == null)
            throw new ArgumentException($"Product with ID {product.Id} not found");

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        return existingProduct;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await Task.Delay(100); // Simular operación asíncrona
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return false;

        return _products.Remove(product);
    }
} 