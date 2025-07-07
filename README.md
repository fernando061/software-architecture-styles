# Arquitectura en Capas (Layered Pattern) - Ejemplo en C#

Este proyecto demuestra la implementación del patrón de arquitectura en capas (Layered Architecture) en C# usando .NET 6.

## 📋 Descripción

La arquitectura en capas es un patrón arquitectónico que organiza el código en capas horizontales, donde cada capa tiene responsabilidades específicas y solo puede comunicarse con las capas adyacentes.

## 🏗️ Estructura del Proyecto

```
software-architecture-styles/
├── Core/                   # Capa de Dominio (Domain Layer)
│   ├── Entity/             # Entidades del dominio
│   │   └── Product.cs      # Entidad Producto
│   └── Interfaces/         # Contratos/Interfaces
│       ├── IProductRepository.cs
│       └── IProductService.cs
├── Infrastructure/         # Capa de Datos (Data Layer)
│   └── Repositories/       # Implementaciones de repositorios
│       └── ProductRepository.cs
├── Service/                # Capa de Servicios (Service Layer)
│   └── ProductService.cs   # Lógica de negocio
└── Console/                # Capa de Presentación (Presentation Layer)
    └── Program.cs          # Aplicación de consola
```

## 🎯 Capas de la Arquitectura

### 1. **Capa de Dominio (Core)**
- **Responsabilidad**: Contiene las entidades del negocio y las interfaces
- **Componentes**:
  - `Product.cs`: Entidad que representa un producto
  - `IProductRepository.cs`: Contrato para acceso a datos
  - `IProductService.cs`: Contrato para lógica de negocio

### 2. **Capa de Datos (Infrastructure)**
- **Responsabilidad**: Implementa el acceso a datos
- **Componentes**:
  - `ProductRepository.cs`: Implementación del repositorio con almacenamiento en memoria

### 3. **Capa de Servicios (Service)**
- **Responsabilidad**: Contiene la lógica de negocio
- **Componentes**:
  - `ProductService.cs`: Implementa las reglas de negocio y validaciones

### 4. **Capa de Presentación (Console)**
- **Responsabilidad**: Interfaz de usuario y orquestación
- **Componentes**:
  - `Program.cs`: Aplicación de consola que demuestra el uso

## 🔄 Flujo de Datos

```
Console (UI) → Service (Business Logic) → Repository (Data Access) → In-Memory Storage
```

## ✨ Características Implementadas

- **CRUD Completo**: Crear, Leer, Actualizar y Eliminar productos
- **Validaciones de Negocio**: Precios válidos, nombres no vacíos, etc.
- **Manejo de Errores**: Excepciones apropiadas para casos de error
- **Operaciones Asíncronas**: Uso de async/await para simular operaciones de base de datos
- **Inyección de Dependencias**: Separación de responsabilidades mediante interfaces

## 🚀 Cómo Ejecutar

1. **Compilar el proyecto**:
   ```bash
   dotnet build
   ```

2. **Ejecutar la aplicación**:
   ```bash
   dotnet run --project Console
   ```

## 📊 Ejemplo de Salida

```
=== Arquitectura en Capas (Layered Pattern) - Ejemplo de Productos ===

1. OBTENER TODOS LOS PRODUCTOS:
--------------------------------
   ID: 1, Name: Laptop, Price: $999.99, Created: 2024-01-15 10:30
   ID: 2, Name: Mouse, Price: $25.50, Created: 2024-01-17 10:30
   ID: 3, Name: Keyboard, Price: $75.00, Created: 2024-01-18 10:30

2. OBTENER PRODUCTO POR ID:
---------------------------
   Producto encontrado: ID: 1, Name: Laptop, Price: $999.99, Created: 2024-01-15 10:30

3. CREAR NUEVO PRODUCTO:
------------------------
   Producto creado: ID: 4, Name: Monitor 4K, Price: $299.99, Created: 2024-01-20 10:30

4. ACTUALIZAR PRODUCTO:
----------------------
   Producto actualizado: ID: 2, Name: Mouse Gaming Pro, Price: $45.99, Created: 2024-01-17 10:30

5. ELIMINAR PRODUCTO:
--------------------
   Producto con ID 3 eliminado exitosamente.

6. MANEJO DE ERRORES:
--------------------
   Error capturado: Product price must be greater than 0.
   Error capturado: Product with ID 999 not found.
   Error capturado: Product with ID 999 not found.
```

## 🎯 Beneficios de esta Arquitectura

1. **Separación de Responsabilidades**: Cada capa tiene una responsabilidad específica
2. **Mantenibilidad**: Cambios en una capa no afectan otras
3. **Testabilidad**: Fácil de unit testear cada capa por separado
4. **Escalabilidad**: Fácil agregar nuevas funcionalidades
5. **Reutilización**: Las capas pueden reutilizarse en diferentes contextos

## 🔧 Próximos Pasos

- Implementar una base de datos real (SQL Server, PostgreSQL)
- Agregar logging y monitoreo
- Implementar autenticación y autorización
- Crear una API REST en lugar de consola
- Agregar tests unitarios y de integración
- Implementar un contenedor de inyección de dependencias (DI Container)

## 📚 Referencias

- [Grischa L - Layered Architecture](https://youtu.be/WiXp2p4obe4)

