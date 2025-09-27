# .NET Core 5 Learning Application

A comprehensive .NET Core 5 application demonstrating enterprise-level patterns and best practices for learning purposes.

## 🏗️ Architecture

This application follows **Clean Architecture** principles with the following layers:

- **API Layer** (`LearningApp.API`): Controllers, middleware, and API configuration
- **Core Layer** (`LearningApp.Core`): Domain entities, DTOs, interfaces, and business logic
- **Infrastructure Layer** (`LearningApp.Infrastructure`): Data access, repositories, and external services
- **Tests** (`LearningApp.Tests`): Unit and integration tests

## 🚀 Key Features & Concepts Demonstrated

### 1. **Clean Architecture**
- Separation of concerns
- Dependency inversion
- Domain-driven design principles

### 2. **Entity Framework Core**
- Code-first approach
- Migrations
- Relationships and navigation properties
- Query optimization
- Database seeding

### 3. **Identity & Authentication**
- ASP.NET Core Identity
- JWT token authentication
- Role-based authorization
- Password policies

### 4. **Repository Pattern & Unit of Work**
- Generic repository implementation
- Unit of Work pattern for transaction management
- Dependency injection

### 5. **CQRS with MediatR**
- Command Query Responsibility Segregation
- Request/Response pattern
- Decoupled handlers

### 6. **AutoMapper**
- Object-to-object mapping
- DTO transformations
- Custom mapping profiles

### 7. **Validation**
- FluentValidation for business rules
- Model validation
- Custom validators

### 8. **Logging**
- Structured logging with Serilog
- File and console logging
- Log levels and filtering

### 9. **Exception Handling**
- Global exception middleware
- Custom error responses
- Environment-specific error details

### 10. **API Documentation**
- Swagger/OpenAPI integration
- JWT authentication in Swagger
- Comprehensive API documentation

### 11. **Testing**
- Unit tests with xUnit
- Mocking with Moq
- Test-driven development examples

### 12. **Configuration Management**
- appsettings.json configuration
- Environment-specific settings
- Strongly-typed configuration

## 📁 Project Structure

```
LearningApp/
├── src/
│   ├── LearningApp.API/           # Web API layer
│   │   ├── Controllers/           # API controllers
│   │   ├── Middleware/           # Custom middleware
│   │   ├── Services/             # Application services
│   │   └── Program.cs            # Application entry point
│   ├── LearningApp.Core/         # Domain layer
│   │   ├── Entities/             # Domain entities
│   │   ├── DTOs/                 # Data transfer objects
│   │   ├── Interfaces/           # Abstractions
│   │   ├── Commands/             # CQRS commands
│   │   ├── Queries/              # CQRS queries
│   │   ├── Validators/           # FluentValidation validators
│   │   └── Enums/                # Enumerations
│   └── LearningApp.Infrastructure/ # Infrastructure layer
│       ├── Data/                 # DbContext and configurations
│       ├── Repositories/         # Repository implementations
│       ├── Handlers/             # MediatR handlers
│       └── Mapping/              # AutoMapper profiles
├── tests/
│   └── LearningApp.Tests/        # Unit tests
└── LearningApp.sln               # Solution file
```

## 🛠️ Technologies Used

- **.NET Core 5.0**
- **Entity Framework Core 5.0**
- **ASP.NET Core Identity**
- **JWT Authentication**
- **MediatR** (CQRS pattern)
- **AutoMapper** (Object mapping)
- **FluentValidation** (Validation)
- **Serilog** (Logging)
- **Swagger/OpenAPI** (API documentation)
- **xUnit** (Testing framework)
- **Moq** (Mocking framework)
- **SQL Server** (Database)

## 🚀 Getting Started

### Prerequisites
- .NET 5.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2019/2022 or VS Code

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd LearningApp
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Update database connection string**
   - Edit `src/LearningApp.API/appsettings.json`
   - Update the `DefaultConnection` string

4. **Run database migrations**
   ```bash
   cd src/LearningApp.API
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Access Swagger UI**
   - Navigate to `https://localhost:5001/swagger`

## 📚 Learning Objectives

This application demonstrates:

1. **Enterprise Architecture Patterns**
   - Clean Architecture
   - Repository Pattern
   - Unit of Work
   - CQRS
   - Dependency Injection

2. **Data Access Patterns**
   - Entity Framework Core
   - Code-first migrations
   - Relationship mapping
   - Query optimization

3. **Security Best Practices**
   - JWT authentication
   - Password hashing
   - Authorization policies
   - Secure API endpoints

4. **API Development**
   - RESTful API design
   - HTTP status codes
   - Content negotiation
   - API versioning concepts

5. **Testing Strategies**
   - Unit testing
   - Integration testing
   - Mocking dependencies
   - Test data builders

6. **Cross-cutting Concerns**
   - Logging
   - Exception handling
   - Validation
   - Configuration management

## 🔧 Configuration

### JWT Settings
```json
{
  "JwtSettings": {
    "SecretKey": "YourSuperSecretKeyThatIsAtLeast32CharactersLong!",
    "Issuer": "LearningApp",
    "Audience": "LearningAppUsers",
    "ExpiryInMinutes": 60
  }
}
```

### Database Connection
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LearningAppDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

## 🧪 Running Tests

```bash
cd tests/LearningApp.Tests
dotnet test
```

## 📖 API Endpoints

### Authentication
- `POST /api/auth/register` - User registration
- `POST /api/auth/login` - User login

### Products
- `GET /api/products` - Get all products (with filtering)
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create new product (authenticated)
- `PUT /api/products/{id}` - Update product (authenticated)
- `DELETE /api/products/{id}` - Delete product (authenticated)

## 🎯 Key Learning Points

1. **Separation of Concerns**: Each layer has a specific responsibility
2. **Dependency Inversion**: High-level modules don't depend on low-level modules
3. **Single Responsibility**: Each class has one reason to change
4. **Open/Closed Principle**: Open for extension, closed for modification
5. **Interface Segregation**: Clients shouldn't depend on interfaces they don't use
6. **DRY Principle**: Don't Repeat Yourself
7. **SOLID Principles**: Applied throughout the application

## 🔍 Code Examples to Study

1. **Generic Repository Pattern**: `Repository<T>` class
2. **CQRS Implementation**: Commands and Queries with handlers
3. **Custom Middleware**: `ExceptionMiddleware` for global error handling
4. **JWT Token Service**: `TokenService` for authentication
5. **FluentValidation**: `CreateProductValidator` for business rules
6. **AutoMapper Profiles**: `MappingProfile` for object mapping
7. **Unit Testing**: Various test classes demonstrating testing patterns

This application serves as a comprehensive reference for .NET Core 5 development best practices and enterprise patterns.