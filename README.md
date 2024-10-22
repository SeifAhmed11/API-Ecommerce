# eCommerce API - ASP.NET Core

## Overview

This project is an eCommerce API built with ASP.NET Core, focusing on creating scalable and performant backend services for eCommerce platforms. The project implements key features such as basket management, identity and authentication using JWT, order management, error handling, caching, and payment integration. It follows best practices for API development and clean architecture principles.

## Features

- **JWT Authentication**: Secure user authentication using JSON Web Tokens (JWT).
- **Basket Management**: API endpoints for managing user baskets, adding/removing items.
- **User Authentication and Identity**: Built-in support for user authentication using ASP.NET Core Identity and JWT tokens.
- **Order Management**: Create, update, and track orders through the API.
- **Error Handling**: Comprehensive error handling with clear messages and status codes.
- **Caching**: Response caching to optimize performance for frequently accessed data.
- **Pagination, Filtering, and Sorting**: Support for paginated responses, filtering, and sorting for product listings.
- **Payment Integration**: Secure payment handling via external payment gateways.
- **Performance Optimizations**: Best practices for API performance tuning, including caching and asynchronous operations.

## Technologies Used

- **ASP.NET Core 6.0**
- **Entity Framework Core**: For data access and persistence.
- **SQL Server**: Database for storing user and order information.
- **Swagger**: API documentation and testing.
- **Identity & JWT**: For secure user authentication and authorization.
- **Automapper**: For object mapping and transforming between layers.
- **Generic Repository Pattern**: To implement reusable data access logic.
- **Response Caching**: To optimize the performance of frequently requested API resources.


## JWT Authentication

The project uses **JSON Web Tokens (JWT)** for secure user authentication. Once a user logs in or registers, the API generates a JWT token that must be included in the `Authorization` header for subsequent requests to protected endpoints.


## Caching

Caching is implemented to improve performance for frequently accessed data, reducing the load on the database and providing faster response times.

- **Response Caching**: The API caches specific data (like product listings) to minimize repetitive database queries.
- **Distributed Caching**: This can be extended using Redis or another distributed cache provider for larger-scale systems.

To control caching behavior, specific cache headers are used. For example, `Cache-Control` can be set to manage cache duration:


## Performance Considerations

- **JWT**: Stateless token-based authentication reduces the need for server-side session storage.
- **Caching**: Response caching optimizes performance for read-heavy operations.
- **Async Operations**: Asynchronous database access using `async/await` for improved scalability.

## Future Improvements

- Integration with third-party shipping services.
- Real-time notifications for order updates.
- Enhanced security features like two-factor authentication.
- A companion Angular frontend for full-stack functionality.

