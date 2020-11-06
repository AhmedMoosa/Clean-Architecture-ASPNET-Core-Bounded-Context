# Clean Architecture ASP.NET Core Bounded Context Sample

## Clean Architecture

- Clean Architecture Design
- ASP.NET Core 3.1
- Entity Framework Core
- CRUD Operations
- Repository Pattern
- Dependency Injection
- AutoMapper

## Bounded Context

- DbContext for each domain (ex: Users , Todos ,....).
- Specify database schema for each DbContext in the same database.
- Create migration history table for each DbContext in the same database.
- Update-database to run migration for all bounded context at runtime .
