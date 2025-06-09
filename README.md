# Vehicle Fleet Management API

## Overview

This is a RESTful API built with .NET 8 for managing a fleet of vehicles (buses, trucks, and cars). The system allows you to create, update, list, and retrieve vehicles by chassis identifier. The project is designed using **Clean Architecture** and **SOLID** principles, ensuring clear separation of concerns, testability, and maintainability.

## Features

- **Insert a new vehicle:** Register a vehicle with all required attributes. Duplicate chassis IDs are not allowed.
- **Edit an existing vehicle:** Update only the color of a vehicle, identified by its chassis ID.
- **List all vehicles:** Retrieve all registered vehicles with their details.
- **Find a vehicle by chassis ID:** Retrieve the details of a vehicle using its chassis identifier.

## Architecture

The project follows **Clean Architecture**, organizing code into distinct layers:

- **Domain:** Business entities, enums, and repository interfaces.
- **Application:** Application services, DTOs, AutoMapper profiles, and service interfaces.
- **Infra.Data:** Repository implementations (in-memory), auxiliary services, and dependency injection configuration.
- **API:** Presentation layer, containing controllers and the application entry point.

## Technologies

- .NET 8
- ASP.NET Core Web API
- AutoMapper
- Swagger (Swashbuckle)
- Dependency Injection (IoC)
- Data validation with Data Annotations
- xUnit, Moq, FluentAssertions (for unit testing)

---

## How to Run

1. **Prerequisites:**  
   - [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed.



3. **Run the application:**
dotnet run --project API


4. **Access Swagger UI:**  
   Open [https://localhost:5001/swagger](https://localhost:7199/swagger) in your browser to explore and test the API endpoints.


![image](https://github.com/user-attachments/assets/31e5de67-c965-4227-aa80-2102b1346e14)




