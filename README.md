# 🚀 .NET API Versioning with Scalar UI

This project demonstrates a clean implementation of **API Versioning in ASP.NET Core (.NET 9)** using URL-based versioning along with a modern API testing interface powered by **Scalar UI**.

---

## 📌 Features

* ✅ RESTful CRUD API for managing Students
* ✅ API Versioning (V1 & V2) using URL segments
* ✅ Separate DTOs for each version
* ✅ Backward compatibility support
* ✅ Clean architecture with Service layer
* ✅ Scalar UI for interactive API testing
* ✅ Lightweight in-memory data storage

---

## 🧱 Tech Stack

* **.NET 9 / ASP.NET Core Web API**
* **API Versioning (Asp.Versioning)**
* **Scalar UI (OpenAPI-based API client)**
* **C#**

---

## 📂 Project Structure

```
Controllers/
 ├── V1/
 │    └── StudentsV1Controller.cs
 ├── V2/
 │    └── StudentsV2Controller.cs

Entities/
 ├── DTOs/
 │    ├── V1/
 │    └── V2/
 └── Models/

Services/
 ├── IStudentService.cs
 └── StudentService.cs
```

---

## 🔄 API Versioning Strategy

This project uses **URL-based versioning**:

```
/api/v1/students
/api/v2/students
```

### 🔹 V1 Response

```json
{
  "id": 1,
  "name": "John Doe"
}
```

### 🔹 V2 Response

```json
{
  "id": 1,
  "firstName": "John",
  "lastName": "Doe"
}
```

---

## 🌐 Scalar API UI

Scalar provides a modern interface to test APIs.

Access it at:

```
https://localhost:{port}/scalar
```

---

## ▶️ Getting Started

1. Clone the repository
2. Run the project
3. Open Scalar UI
4. Test endpoints with version values

---

## 💡 Key Learnings

* How to implement API versioning in real-world applications
* Importance of DTO separation for backward compatibility
* Clean service-based architecture
* Using modern API clients like Scalar instead of Swagger

---

## 📌 Future Enhancements

* Integration with Entity Framework Core
* Database support (SQL Server)
* Authentication & Authorization (JWT)
* AutoMapper for DTO mapping
* Versioning via headers/query params

---

## 🤝 Contribution

Feel free to fork and enhance this project 🚀
