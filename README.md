# Inventory Management System

## Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Folder Structure](#folder-structure)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
  - [Running the Backend](#running-the-backend)
  - [Running the Frontend](#running-the-frontend)
- [API Endpoints](#api-endpoints)
- [Entities](#entities)
- [AutoMapper Setup](#automapper-setup)
- [Behaviors](#behaviors)
- [Contributing](#contributing)

## Overview

The **Inventory Management System** is a comprehensive solution for managing categories, products, product details, product inventory, and suppliers. It is built using a clean architecture approach, with a separation of concerns between the API, application logic, and infrastructure. The system allows users to perform CRUD (Create, Read, Update, Delete) operations on the five entities: Category, Product, ProductDetail, ProductInventory, and Supplier.

## Architecture

The project follows a layered architecture, adhering to the principles of clean architecture and CQRS (Command Query Responsibility Segregation). The main layers are:

- **API**: Handles HTTP requests and responses.
- **Application**: Contains business logic, including commands, queries, and pipeline behaviors.
- **Core**: Contains the domain models and interfaces.
- **Infrastructure**: Contains the implementations of the interfaces defined in the Core layer, such as database access.

## Features

- CRUD operations for Categories, Products, ProductDetails, ProductInventories, and Suppliers.
- Validation, logging, and performance monitoring using MediatR pipeline behaviors.
- AutoMapper integration for mapping between domain models and DTOs.
- Frontend built with React and Tailwind CSS, providing a responsive user interface.

## Technologies Used

- **Backend**:
  - ASP.NET Core
  - Entity Framework Core
  - AutoMapper
  - FluentValidation
  - SQL Server

- **Frontend**:
  - React
  - TypeScript
  - Vite
  - Tailwind CSS
  - Axios

## Folder Structure

```bash
InventoryService/
├── Api/                 # API layer containing controllers
├── Application/         # Application layer containing business logic
│   ├── Behaviors/       # MediatR pipeline behaviors (Validation, Logging, Performance)
│   ├── Mappings/        # AutoMapper profiles
│   ├── Services/        # Application services
│   └── DTOs/            # Data Transfer Objects (DTOs)
├── Core/                # Core layer containing domain models and interfaces
├── Infrastructure/      # Infrastructure layer containing database access
├── Migrations/          # EF Core migrations
└── Properties/          # Application properties and settings
```

```bash
inventory-frontend/
├── public/              # Static assets
├── src/                 # Source files
│   ├── components/      # React components
│   ├── pages/           # React pages
│   ├── services/        # API service calls
│   ├── interfaces/      # TypeScript interfaces
│   ├── App.tsx          # Main app component
│   ├── main.tsx         # Entry point
│   └── index.css        # Global CSS
└── vite.config.ts       # Vite configuration
```

## Getting Started

### Prerequisites

Before you begin, ensure you have the following installed on your machine:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js](https://nodejs.org/) (version 14 or higher)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or use Docker for a containerized instance)

### Installation

#### Backend

1. **Clone the repository**:

```bash
   git clone https://github.com/iaashu98/inventory-management-system.git
   cd inventory-management-system/InventoryService
```

2. **Restore NuGet packages**:
```bash
    dotnet restore
```

3. **Update the database**:
Ensure your SQL Server is running and update the database using Entity Framework Core migrations:

```bash
    dotnet ef database update
```
4. **Run the backend**:
```bash
dotnet run
```

#### Frontend

1. **Navigate to the frontend directory**:
```bash
    cd inventory-management-system/inventory-frontend
```

2. **Install npm dependencies**:
```bash
    npm install
```

3. **Run the frontend**:
```bash
    npm run dev
```

## Usage

### Running the Backend
To start the backend server, navigate to the InventoryService directory and run:

```bash
    dotnet run
```

The API will be available at http://localhost:5000.

### Running the Frontend
To start the frontend development server, navigate to the inventory-frontend directory and run:

```bash
   npm run dev
```
The frontend will be available at http://localhost:3000.

## API Endpoints

***Category***
- GET /api/categories: Retrieve all categories.
- GET /api/categories/{id}: Retrieve a category by ID.
- POST /api/categories: Create a new category.
- PUT /api/categories/{id}: Update an existing category.
- DELETE /api/categories/{id}: Delete a category.
- SEARCH /api/categories/search/{searchtext}: Search a category.

**Product**
- GET /api/products: Retrieve all products.
- GET /api/products/{id}: Retrieve a product by ID.
- GET /api/products/{name}: Retrieve a product by Name.
- POST /api/products: Create a new product.
- PUT /api/products/{id}: Update an existing product.
- DELETE /api/products/{id}: Delete a product.
- SEARCH /api/products/search/{searchtext}: Search a product.

**ProductDetail**
- GET /api/productdetails: Retrieve all product details.
- GET /api/productdetails/{id}: Retrieve product details by ID.
- POST /api/productdetails: Create new product details.
- PUT /api/productdetails/{id}: Update existing product details.
- DELETE /api/productdetails/{id}: Delete product details.
- SEARCH /api/productdetails/search/{searchtext}: Search a product details.

**ProductInventory**
- GET /api/productinventories: Retrieve all product inventories.
- GET /api/productinventories/{id}: Retrieve product inventory by ID.
- POST /api/productinventories: Create a new product inventory.
- PUT /api/productinventories/{id}: Update an existing product inventory.
- DELETE /api/productinventories/{id}: Delete a product inventory.

**Supplier**
- GET /api/suppliers: Retrieve all suppliers.
- GET /api/suppliers/{id}: Retrieve a supplier by ID.
- POST /api/suppliers: Create a new supplier.
- PUT /api/suppliers/{id}: Update an existing supplier.
- DELETE /api/suppliers/{id}: Delete a supplier.
- SEARCH /api/suppliers/search/{searchtext}: Search a supplier.


## Entities

### Category
Represents a category to which products belong. It contains fields such as CategoryID, CategoryName, and Description.

### Product
Represents a product in the inventory. It contains fields such as ProductID, ProductName, CategoryID, SupplierID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, and Discontinued.

### ProductDetail
Represents additional details about a product, such as ProductDetailID, ProductID, Description, Specifications, WarrantyPeriod, and Manufacturer.

### ProductInventory
Represents the inventory details of a product, including InventoryID, ProductID, Quantity, WarehouseLocation, and LastUpdated.

### Supplier
Represents a supplier from whom products are sourced. It includes fields such as SupplierID, SupplierName, ContactName, Address, City, PostalCode, Country, Phone, and Email.

## AutoMapper Setup

AutoMapper is used to map between domain models and DTOs. The mapping profiles are located in the Application/Mappings folder.

### Adding a New Mapping
To add a new mapping, create a profile in the Mappings folder:

```csharp

public class NewEntityProfile : Profile
{
    public NewEntityProfile()
    {
        CreateMap<NewEntity, NewEntityDTO>().ReverseMap();
    }
}
```

## Behaviors

MediatR pipeline behaviors are used for cross-cutting concerns like validation, logging, and performance monitoring. These behaviors are located in the Application/Behaviors folder.

### ValidationBehavior
It ensures that all incoming requests are validated according to the rules defined using FluentValidation.

### LoggingBehavior
Logs details about the requests and responses, which is helpful for debugging and monitoring.

### PerformanceBehavior
Monitors the time taken to execute a request, logging warnings for slow operations.

## Contributing

Contributions are welcome! Please fork this repository, create a new branch, and submit a pull request. Ensure that your code adheres to the existing code style and includes appropriate tests.

