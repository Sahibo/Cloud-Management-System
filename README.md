# 🌩️ CloudManagementAPI

**A university project(Object Oriented Programming) simulating cloud infrastructure management using ASP.NET Core Web API, Entity Framework, and MSSQL.**

## 📚 Project Overview

CloudManagementAPI is a backend API designed to manage cloud resources such as Virtual Machines and Storage Buckets. The system follows **Clean Architecture** principles and demonstrates real-world patterns like **repository/service abstraction**, **TPT (Table-per-Type) inheritance**, and **unit testing with Moq**.

---

## ⚙️ Technologies Used

- **.NET 8 / ASP.NET Core Web API**
- **Entity Framework Core (EF Core)**
- **MSSQL Server**
- **AutoMapper**
- **Swagger / Swashbuckle**
- **xUnit & Moq (for unit testing)**

---

## 📁 Features

- ✅ CRUD operations for:
  - Virtual Machines
  - Storage Buckets
- ✅ TPT inheritance model with a shared `CloudResource` base
- ✅ Clean Architecture with:
  - Controllers
  - Services (with interfaces)
  - Repositories (with interfaces)
- ✅ DTOs & AutoMapper for clean object mapping
- ✅ Swagger UI for API testing
- ✅ .http file for local API testing
- ✅ Unit tests for all services using Moq

---

## 🧱 Architecture

- /CloudManagementAPI
 - ├── Controllers/
 - ├── Data/ (DbContext)
 - ├── Dtos/
 - ├── Interfaces/
 - │ ├── Repositories
 - │ └── Services
 - ├── Models/
 - ├── Repositories/
 - ├── Services/
 - ├── Tests/
 - └── CloudManagementAPI.http

---

## 🚀 Getting Started

### Prerequisites

- .NET 9
- appsettings.json or LocalDB

### Run the API

```bash
dotnet run
Then open https://localhost:{your port}/index.html to explore the API.

🧪 Run Tests
bash

cd CloudManagementAPI.Tests
dotnet test
```
## 🎓 Author
### This project was created as part of a university assignment focused on backend architecture, testability, and clean coding practices.

