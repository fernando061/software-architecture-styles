# Ejemplo de Arquitectura MVC en .NET Core 6

Este proyecto demuestra una implementación básica y funcional del patrón de arquitectura **Model-View-Controller (MVC)** en ASP.NET Core 6.

## 🏗️ Estructura del Proyecto

### 📁 Models (Modelos)
- **Product.cs**: Representa la entidad de negocio con validaciones
- Define la estructura de datos y las reglas de validación

### 📁 Controllers (Controladores)
- **ProductsController.cs**: Maneja las peticiones HTTP y la lógica de presentación
- Implementa todas las operaciones CRUD (Create, Read, Update, Delete)

### 📁 Views (Vistas)
- **Index.cshtml**: Lista todos los productos
- **Create.cshtml**: Formulario para crear nuevos productos
- **Details.cshtml**: Muestra los detalles de un producto
- **Edit.cshtml**: Formulario para editar productos existentes
- **Delete.cshtml**: Confirmación para eliminar productos

### 📁 Services (Servicios)
- **IProductService.cs**: Interfaz que define los contratos del servicio
- **ProductService.cs**: Implementación del servicio con datos en memoria

## 🚀 Características Implementadas

### ✅ Operaciones CRUD Completas
- **Crear** productos nuevos
- **Leer** lista de productos y detalles individuales
- **Actualizar** productos existentes
- **Eliminar** productos con confirmación

### ✅ Validaciones
- Validación del lado del servidor con Data Annotations
- Validación del lado del cliente con JavaScript
- Mensajes de error personalizados

### ✅ Interfaz de Usuario
- Diseño responsive con Bootstrap 5
- Iconos de Font Awesome
- Mensajes de confirmación y éxito
- Navegación intuitiva

### ✅ Arquitectura MVC
- **Separación de responsabilidades** clara
- **Inyección de dependencias** para servicios
- **Routing** automático de ASP.NET Core
- **Model Binding** automático

## 🛠️ Cómo Ejecutar

1. **Navegar al directorio del proyecto:**
   ```bash
   cd MvcExample
   ```

2. **Restaurar dependencias:**
   ```bash
   dotnet restore
   ```

3. **Ejecutar la aplicación:**
   ```bash
   dotnet run
   ```

4. **Abrir en el navegador:**
   ```
   https://localhost:7001
   ```

## 📋 Funcionalidades del Ejemplo

### 🏠 Página Principal
- Redirige automáticamente a la lista de productos
- Muestra productos de ejemplo pre-cargados

### 📦 Gestión de Productos
- **Ver lista**: Tabla con todos los productos
- **Crear nuevo**: Formulario con validaciones
- **Ver detalles**: Información completa del producto
- **Editar**: Formulario pre-llenado con datos actuales
- **Eliminar**: Confirmación antes de eliminar

### 🎨 Características de UI/UX
- Diseño moderno y responsive
- Iconos intuitivos
- Mensajes de feedback
- Navegación clara
- Formularios bien estructurados

## 🔧 Tecnologías Utilizadas

- **.NET Core 6**
- **ASP.NET Core MVC**
- **Bootstrap 5**
- **Font Awesome 6**
- **jQuery** (para validaciones del cliente)
- **Data Annotations** (para validaciones del servidor)

## 📚 Conceptos MVC Demostrados

### Model (Modelo)
- Representa los datos y la lógica de negocio
- Contiene validaciones y reglas de dominio
- Es independiente de la interfaz de usuario

### View (Vista)
- Presenta los datos al usuario
- Maneja la interacción del usuario
- Es pasiva y no contiene lógica de negocio

### Controller (Controlador)
- Recibe las peticiones del usuario
- Coordina entre el modelo y la vista
- Maneja la lógica de presentación

## 🎯 Beneficios de esta Arquitectura

1. **Separación de Responsabilidades**: Cada componente tiene una función específica
2. **Mantenibilidad**: Fácil de mantener y modificar
3. **Testabilidad**: Componentes independientes fáciles de probar
4. **Escalabilidad**: Fácil de extender con nuevas funcionalidades
5. **Reutilización**: Componentes pueden reutilizarse en diferentes contextos

Este ejemplo proporciona una base sólida para entender y aplicar el patrón MVC en aplicaciones web con .NET Core.

## 📚 Referencias

- [Grischa L - Layered Architecture](https://youtu.be/G3_swUprvd0)