# Vaccination Card API – .NET 10 REST API

This project provides a fully documented and production-ready REST API for managing vaccines, users, and vaccination records.
It is developed using **.NET 10**, **Entity Framework Core**, and follows clean REST architecture standards.

## Purpose

The goal of this API is to provide a complete backend system capable of:

* Registering vaccines
* Registering users
* Managing each user’s vaccination card
* Validating doses
* Enforcing relational constraints and cascade delete
* Returning structured and predictable JSON responses

---

## Technologies Used

* **.NET 10 Web API**
* **Entity Framework Core 10**
* **SQLite** (default)
* **Swagger / Swashbuckle**
* **Dependency Injection**
* **Async/Await** for all DB operations

---

## Features Overview

### Vaccine Management

* Create, list, update, and delete vaccines

### User Management

* Create, list (all or by ID/name), update, and delete users
* Deleting a user automatically deletes all vaccination records (Cascade Delete)

### Vaccination Record Management

* Register vaccinations for a specific user
* Validate vaccine existence
* Validate dose number (must be ≥ 1)
* Prevent duplicate dose entries using a unique constraint
* Full CRUD operations for vaccination records

---

## Data Model Diagram

```
User (1)
 └─── (N) VaccinationRecord (N)
               └─── (1) Vaccine
```

---

## How to Run

### 1. Restore dependencies

```
dotnet restore
```

### 2. Apply database migrations

```
dotnet ef database update
```

### 3. Run the API

```
dotnet run
```

### 4. Access Swagger documentation

```
http://localhost:5132/swagger
```

---

## API Endpoints Reference

### User Endpoints

| Method | Route               | Description                                       |
| ------ | ------------------- | ------------------------------------------------- |
| GET    | `/api/user`         | List all users                                    |
| GET    | `/api/user/{value}` | Get user by ID or name                            |
| POST   | `/api/user`         | Create a user                                     |
| PUT    | `/api/user/{id}`    | Update user name                                  |
| DELETE | `/api/user/{id}`    | Delete user (cascade deletes vaccination records) |

---

### Vaccine Endpoints

| Method | Route                  | Description               |
| ------ | ---------------------- | ------------------------- |
| GET    | `/api/vaccine`         | List all vaccines         |
| GET    | `/api/vaccine/{value}` | Get vaccine by ID or name |
| POST   | `/api/vaccine`         | Create a vaccine          |
| PUT    | `/api/vaccine/{id}`    | Update vaccine            |
| DELETE | `/api/vaccine/{id}`    | Delete vaccine            |

---

### Vaccination Record Endpoints

| Method | Route                                               | Description                 |
| ------ | --------------------------------------------------- | --------------------------- |
| GET    | `/api/users/{userId}/vaccinationrecords`            | Get all records for a user  |
| GET    | `/api/users/{userId}/vaccinationrecords/{recordId}` | Get a single record         |
| POST   | `/api/users/{userId}/vaccinationrecords`            | Add a vaccination record    |
| PUT    | `/api/users/{userId}/vaccinationrecords/{recordId}` | Update a vaccination record |
| DELETE | `/api/users/{userId}/vaccinationrecords/{recordId}` | Delete a vaccination record |

---

## Business Rules Implemented

* Users must exist to register a vaccination
* Vaccines must exist and be valid
* Dose must be **≥ 1**
* Duplicate doses are prevented using a unique index `(UserID, VaccineID, DoseNumber)`
* Cascade delete ensures a user's vaccination history is removed upon deletion
* All responses use standardized JSON patterns

---

## Optional Improvements

* DTOs with validation attributes
* JWT Authentication
* Unit Tests using EF InMemoryDatabase
* Angular Front-End for visualizing vaccination cards
* Filtering, search and pagination

---

## Author

Developed by **Victor Augusto**
GitHub: [https://github.com/vaugusto273](https://github.com/vaugusto273)
