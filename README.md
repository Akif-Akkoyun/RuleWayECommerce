# RuleWayECommerce

RuleWayECommerce is a .NET 8 Web API project developed for an e-commerce merchandising management case.

The main purpose of this project is to provide a clean and testable business flow for Product CRUD operations, category-based stock validation, and product filtering.

The project was designed according to the given case requirements:

- Product must include title, description, category, and stock quantity.
- Each product can have only one category.
- A product must have a category to be live.
- Each category has a minimum stock quantity rule.
- Products below the category minimum stock quantity cannot be live.
- Products can be filtered by keyword and stock quantity range.

---

## Technologies Used

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- CQRS Pattern
- MediatR
- Repository Pattern
- Layered Architecture
- Swagger / OpenAPI
- Automatic Database Migration
- Automatic Seed Data on Startup

---

## Project Structure

```text
RuleWayECommerce
├── Core
│   ├── RuleWayECommerce.Domain
│   └── RuleWayECommerce.Application
├── Infrastructure
│   └── RuleWayECommerce.Persistence
└── Presentation
    └── RuleWayECommerce.WebApi
```

---

## Architecture Overview

The project follows a layered architecture approach.

### Domain Layer

Contains the core entities of the application.

Main entities:

- ProductEntity
- CategoryEntity
- BaseEntity

### Application Layer

Contains CQRS structures, commands, queries, handlers, results, repository interfaces, and business rules.

Main folders:

- Features
- Commands
- Queries
- Handlers
- Results
- Interfaces

### Persistence Layer

Contains database access logic, EF Core DbContext, entity configurations, repositories, migrations, and seed data.

Main folders:

- AppDbContext
- Configurations
- Repositories
- Migrations
- SeedData

### Web API Layer

Contains controllers, API configuration, middleware extensions, migration startup logic, and Swagger configuration.

Main folders:

- Controllers
- WebApiExtensions

---

## Main Features

- Product CRUD operations
- Category CRUD operations
- One-to-many relationship between Category and Product
- Product can have only one category
- Product cannot be live without a valid category
- Category-level minimum stock quantity validation
- Product cannot be live if its stock quantity is below the category minimum stock quantity
- Product filtering by keyword
- Product filtering by stock quantity range
- Automatic EF Core migration execution on application startup
- Automatic seed data insertion on first startup
- Swagger UI support for API testing

---

## Business Rules

### Product Rules

- Product title cannot be null or empty.
- Product title has a maximum length of 200 characters.
- Product description is required.
- Product stock quantity is required.
- Product can only have one category.
- Product must have a category to be live.
- If a product's stock quantity is below the category minimum stock quantity, it cannot be live.

### Category Rules

- Category has a name.
- Category has a minimum stock quantity.
- Category can have multiple products.

---

## API Endpoints

### Category Endpoints

```http
GET     /api/Category/category-list
GET     /api/Category/get-category-by/{id}
POST    /api/Category/create
PUT     /api/Category/update/{id}
DELETE  /api/Category/delete/{id}
```

### Product Endpoints

```http
GET     /api/Product/product-list
GET     /api/Product/get-product-by/{id}
GET     /api/Product/filter?keyword=phone&minStock=10&maxStock=100
POST    /api/Product/create
PUT     /api/Product/update/{id}
DELETE  /api/Product/delete/{id}
```

---

## Product Filter Logic

The product filter endpoint supports optional query parameters.

Example request:

```http
GET /api/Product/filter?keyword=phone&minStock=10&maxStock=100
```

### Filtering Criteria

The `keyword` value is searched in the following fields:

- Product title
- Product description
- Category name

The `minStock` value returns products whose stock quantity is greater than or equal to the given value.

The `maxStock` value returns products whose stock quantity is less than or equal to the given value.

### Example Filter Requests

```http
GET /api/Product/filter?keyword=phone
```

```http
GET /api/Product/filter?minStock=10
```

```http
GET /api/Product/filter?maxStock=100
```

```http
GET /api/Product/filter?minStock=10&maxStock=100
```

```http
GET /api/Product/filter?keyword=book&minStock=5&maxStock=50
```

---

## Sample Product Create Request

```json
{
  "title": "iPhone 15",
  "description": "Apple smartphone with high performance camera and display.",
  "stockQuantity": 50,
  "isLive": true,
  "categoryId": "11111111-1111-1111-1111-111111111111"
}
```

If `isLive` is true, the product stock quantity must be greater than or equal to the selected category minimum stock quantity.

---

## Sample Category Create Request

```json
{
  "name": "Electronics",
  "minimumStockQuantity": 10
}
```

---

## Seed Data

The application automatically inserts sample categories and products on startup if the database is empty.

Seed categories:

- Electronics
- Clothing
- Books

Seed products:

- iPhone 15
- Samsung Galaxy S24
- Basic White T-Shirt
- Slim Fit Jeans
- Clean Code
- Domain-Driven Design

Some products are inserted as `IsLive = false` because their stock quantity is below the related category minimum stock quantity. This allows the business rule to be tested easily.

---

## Automatic Migration and Seed Data

The application automatically applies pending EF Core migrations and inserts seed data on startup.

When the Web API project starts:

1. Pending migrations are applied.
2. Database is created if it does not exist.
3. Seed data is inserted if the database is empty.
4. Swagger UI can be used to test the API.

This means that after cloning the repository, the user only needs to update the connection string and run the Web API project.

---

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/Akif-Akkoyun/RuleWayECommerce.git
```

### 2. Open the Project

Open the solution file:

```text
RuleWayECommerce.sln
```

### 3. Update Connection String

Update the `DefaultConnection` value in `appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=RuleWayECommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

### 4. Run the Web API Project

Set `RuleWayECommerce.WebApi` as the startup project and run the application.

The application will automatically:

- Apply migrations
- Create database tables
- Insert seed data
- Open Swagger UI

---

## Swagger

Swagger UI is enabled for API testing.

After running the project, Swagger can be accessed from the browser.

Example:

```text
https://localhost:{port}/swagger
```

---

## Notes

This project was developed as a case study for an e-commerce product management system.

The focus of the project is:

- Clean project structure
- Simple and understandable business flow
- CQRS-based request handling
- Repository-based database access
- Entity Framework Core configuration
- API-based product and category management
- Easy testing with Swagger and seed data

---

## License

This project is licensed under the MIT License.
