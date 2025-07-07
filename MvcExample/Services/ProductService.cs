using MvcExample.Models;

namespace MvcExample.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products;
        private int _nextId = 1;

        public ProductService()
        {
            // Datos de ejemplo para demostrar la funcionalidad
            _products = new List<Product>
            {
                new Product { Id = _nextId++, Name = "Laptop HP", Description = "Laptop de alta gama", Price = 999.99m, Category = "Electrónicos", CreatedDate = DateTime.Now.AddDays(-5) },
                new Product { Id = _nextId++, Name = "Mouse Inalámbrico", Description = "Mouse ergonómico", Price = 29.99m, Category = "Accesorios", CreatedDate = DateTime.Now.AddDays(-3) },
                new Product { Id = _nextId++, Name = "Teclado Mecánico", Description = "Teclado gaming RGB", Price = 89.99m, Category = "Accesorios", CreatedDate = DateTime.Now.AddDays(-1) }
            };
        }

        public List<Product> GetAllProducts()
        {
            return _products.OrderBy(p => p.Name).ToList();
        }

        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            product.Id = _nextId++;
            product.CreatedDate = DateTime.Now;
            _products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Category = product.Category;
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
} 