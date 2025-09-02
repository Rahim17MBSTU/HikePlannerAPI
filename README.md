# HikePlannerAPI

A **RESTful ASP.NET Core Web API** for managing Walks, Regions, and Difficulties. This project demonstrates **CRUD Operation, maintain separation of concern in using Repository Pattern, DTOs, AutoMapper, Data Annotations** in a professional web API.

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
- **Swagger for API testing
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

### Difficulties
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | /api/difficulties | Get all difficulty levels |

---

## Setup Instructions

1. **Clone the repository**
```bash
git clone https://github.com/your-username/HikePlannerAPI.git
