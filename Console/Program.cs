using Core.Interfaces;
using Infrastructure.Repositories;
using Service;

namespace Console;

class Program
{
    static async Task Main(string[] args)
    {
        System.Console.WriteLine("=== Arquitectura en Capas (Layered Pattern) - Ejemplo de Productos ===\n");

        // Configuración de dependencias (simulación de DI Container)
        IProductRepository productRepository = new ProductRepository();
        IProductService productService = new ProductService(productRepository);

        try
        {
            // Demostrar todas las operaciones CRUD
            await DemonstrateGetAllProducts(productService);
            await DemonstrateGetProductById(productService);
            await DemonstrateCreateProduct(productService);
            await DemonstrateUpdateProduct(productService);
            await DemonstrateDeleteProduct(productService);
            await DemonstrateErrorHandling(productService);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error inesperado: {ex.Message}");
        }

        System.Console.WriteLine("\nPresiona cualquier tecla para salir...");
        System.Console.ReadKey();
    }

    static async Task DemonstrateGetAllProducts(IProductService productService)
    {
        System.Console.WriteLine("1. OBTENER TODOS LOS PRODUCTOS:");
        System.Console.WriteLine("--------------------------------");
        
        var products = await productService.GetAllProductsAsync();
        foreach (var product in products)
        {
            System.Console.WriteLine($"   {product}");
        }
        System.Console.WriteLine();
    }

    static async Task DemonstrateGetProductById(IProductService productService)
    {
        System.Console.WriteLine("2. OBTENER PRODUCTO POR ID:");
        System.Console.WriteLine("---------------------------");
        
        var product = await productService.GetProductByIdAsync(1);
        if (product != null)
        {
            System.Console.WriteLine($"   Producto encontrado: {product}");
        }
        System.Console.WriteLine();
    }

    static async Task DemonstrateCreateProduct(IProductService productService)
    {
        System.Console.WriteLine("3. CREAR NUEVO PRODUCTO:");
        System.Console.WriteLine("------------------------");
        
        var newProduct = await productService.CreateProductAsync("Monitor 4K", 299.99m);
        System.Console.WriteLine($"   Producto creado: {newProduct}");
        System.Console.WriteLine();
    }

    static async Task DemonstrateUpdateProduct(IProductService productService)
    {
        System.Console.WriteLine("4. ACTUALIZAR PRODUCTO:");
        System.Console.WriteLine("----------------------");
        
        var updatedProduct = await productService.UpdateProductAsync(2, "Mouse Gaming Pro", 45.99m);
        System.Console.WriteLine($"   Producto actualizado: {updatedProduct}");
        System.Console.WriteLine();
    }

    static async Task DemonstrateDeleteProduct(IProductService productService)
    {
        System.Console.WriteLine("5. ELIMINAR PRODUCTO:");
        System.Console.WriteLine("--------------------");
        
        var deleted = await productService.DeleteProductAsync(3);
        if (deleted)
        {
            System.Console.WriteLine("   Producto con ID 3 eliminado exitosamente.");
        }
        System.Console.WriteLine();
    }

    static async Task DemonstrateErrorHandling(IProductService productService)
    {
        System.Console.WriteLine("6. MANEJO DE ERRORES:");
        System.Console.WriteLine("--------------------");
        
        try
        {
            // Intentar crear un producto con precio inválido
            await productService.CreateProductAsync("Producto Inválido", -10m);
        }
        catch (ArgumentException ex)
        {
            System.Console.WriteLine($"   Error capturado: {ex.Message}");
        }

        try
        {
            // Intentar obtener un producto que no existe
            await productService.GetProductByIdAsync(999);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"   Error capturado: {ex.Message}");
        }

        try
        {
            // Intentar actualizar un producto que no existe
            await productService.UpdateProductAsync(999, "Producto Inexistente", 100m);
        }
        catch (ArgumentException ex)
        {
            System.Console.WriteLine($"   Error capturado: {ex.Message}");
        }
        System.Console.WriteLine();
    }
}
