# HikePlannerAPI

A **RESTful ASP.NET Core Web API** for managing Walks, Regions, and Difficulties. This project demonstrates **CRUD Operation, maintaing separation of concern in using Repository Pattern, DTOs, AutoMapper, Data Annotations** in a professional web API.

---

## Table of Contents
- [Project Overview](#project-overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Entities](#entities)
- [API Endpoints](#api-endpoints)
- [Setup Instructions](#setup-instructions)
- [Future Improvements](#future-improvements)
- [Author](#author)

---

## Project Overview
HikePlannerAPI allows users to manage hiking trails (Walks) across different Regions with difficulty levels.  
The API follows **clean architecture principles** and **RESTful standards**, making it scalable and maintainable.

---

## Features
- CRUD operations for **Walks** and **Regions**
- Read operation for **Difficulties**
- Uses **DTOs** to decouple domain models from API contracts
- Implements **Repository Pattern** for data access
- **AutoMapper** for object-to-object mapping
- **Data Annotations** for input validation
- Follows **RESTful API standards** with proper HTTP status codes

---

## Technologies Used
- **ASP.NET Core 8 Web API**
- **Entity Framework Core**
- **AutoMapper**
- **SQL Server** 
- **Swagger for API testing**
- **GitHub** for version control
  
---

## Entities

### Walk
- `Id` (Guid)
- `Name` (string)
- `Length` (double)
- `Description` (string)
- `WalkImageUrl` (string, optional)
- `RegionId` (Guid)
- `DifficultyId` (Guid)
- Navigation Properties: `Region`, `Difficulty`

### Region
- `Id` (Guid)
- `Name` (string)
- `Code` (string)
- `RegionImageUrl` (string, optional)

### Difficulty
- `Id` (Guid)
- `Name` (string) (e.g., Easy, Medium, Hard)

---

## API Endpoints

### Walks
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | /api/walks | Get all walks |
| GET    | /api/walks/{id} | Get a single walk by ID |
| POST   | /api/walks | Create a new walk |
| PUT    | /api/walks/{id} | Update an existing walk |
| DELETE | /api/walks/{id} | Delete a walk |

### Regions
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | /api/regions | Get all regions |
| GET    | /api/regions/{id} | Get a single region |
| POST   | /api/regions | Create a new region |
| PUT    | /api/regions/{id} | Update a region |
| DELETE | /api/regions/{id} | Delete a region |

<!--
### Difficulties
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | /api/difficulties | Get all difficulty levels |
-->
---

## Setup Instructions

1. **Clone the repository**
  ```bash

  git clone https://github.com/Rahim17MBSTU/HikePlannerAPI.git

  ```
2. **Open in Visual Studio 2022 or VS Code**
3. **Install Dependencies**
```bash
dotnet restore
```

4. **Configure the database**
- Update appsettings.json with your SQL Server connection string
- Or use In-Memory database for testing

5. **Apply migrations**
```bash
dotnet ef database update
```
6. **Run the API**
```bash
dotnet run
```

7. **Test API using Swagger**
- Open: https://localhost:5001/swagger/index.html
- Or use Postman


### Screenshots

### Main UI
![Main UI](https://github.com/Rahim17MBSTU/HikePlannerAPI/blob/7836b71d0eaaa8ebf3c070627f066b616c7c1d07/Main%20UI.png?raw=true)

### Swagger UI
![GetById]([https://github.com/Rahim17MBSTU/HikePlannerAPI/blob/main/Screenshots/swagger.png?raw=true](https://github.com/Rahim17MBSTU/HikePlannerAPI/blob/a813b1e8607c845c470b4514bb43a73f78fb1920/GetById.png))

### Example Walks GET Request
![Walks GET](https://github.com/Rahim17MBSTU/HikePlannerAPI/blob/3af52bb22930c7b68b01e86dddcc7003bfc5ba38/Walks%20GET.png?raw=true)




