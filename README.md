# ProyectoEcommerce
Este es un proyecto personal de ecommerce desarrollado con .NET y la arquitectura limpia (Clean Architecture). Está enfocado en el aprendizaje de buenas prácticas de desarrollo profesional y organizado por capas.

---

## 🚀 Tecnologías utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/download)
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **AutoMapper**
- **FluentValidation**
- **MediatR**
- **Visual Studio Code**

---

## 📁 Estructura del proyecto

```plaintext
ProyectoEcommerce/
│
├── src/
│   ├── Ecommerce.API/              # Capa de presentación (Web API)
│   ├── Ecommerce.Aplication/       # Casos de uso, lógica de aplicación
│   ├── Ecommerce.Domain/           # Entidades, interfaces, lógica de dominio
│   └── Ecommerce.Infrastructure/   # Persistencia, acceso a datos, servicios externos
│
├── tests/
│   └── Ecommerce.Tests/            # Pruebas unitarias y de integración
│
├── .gitignore
├── README.md
└── EcommerceApp.sln
```

## ⚙️ Cómo ejecutar el proyecto

1. **Clona este repositorio:**
   ```
   git clone https://github.com/CamiloSTDev/ProyectoEcommerce.git
   cd ProyectoEcommerce
   ```

2. **Restaura los paquetes y compila:**
   ```
   dotnet restore
   dotnet build
   ```

3. **Ejecuta la API:**
   ```
   cd src/Ecommerce.API
   dotnet run
   ```

## 🧱 Funcionalidades planeadas

- ✅ Autenticación y autorización con JWT
- ✅ Registro e inicio de sesión de usuarios
- 🛒 Gestión de productos y categorías
- 🛍️ Carrito de compras
- 💳 Simulación de pasarela de pago

## 🧠 Objetivo del proyecto

- Aprender y Aplicar Clean Architecture en un contexto real
- Practicar los principios SOLID
- Aprender la separación de capas y responsabilidades
- Dominar el uso de EF Core con Code First
- Familiarizarse con patrones comunes en sistemas escalables

## 📌 Estado actual del proyecto

🚧 **En desarrollo** — estructura inicial creada, módulo de autenticación en curso.

## 👤 Autores

**CamiloSTDev**
[GitHub](https://github.com/CamiloSTDev) · [LinkedIn](www.linkedin.com/in/camilo-totena-964b93311)

**KevinSRDev**
[GitHub](https://github.com/KevinSRDev)

Desarrolladores .NET | Entusiastas de la arquitectura limpia  
