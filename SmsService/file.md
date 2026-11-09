# SmsService

SmsService is a simple and extensible SMS sending API built with ASP.NET Core (.NET 8).  
It supports sending messages through a provider abstraction, storing message data in a SQLite database, and running automated tests using xUnit.

---

## 📌 Features

- Send SMS messages through a pluggable provider (FakeSmsProvider).
- Store messages and delivery statuses in a SQLite database.
- REST API for sending and retrieving messages.
- Input validation (phone number format, message length).
- Automated unit tests for critical logic (repository, provider).
- Clean architecture using Dependency Injection.

---

## 📌 Project Structure
SmsService/
│
├── SmsService/               # Main API project
│   ├── Controllers/          # API endpoints
│   ├── Data/                 # EF Core context, entities, repository
│   ├── Models/               # Request models
│   ├── Services/             # SMS provider abstraction
│   ├── Shared/               # Enums and shared types
│   ├── Migrations/           # EF Core migrations
│   └── Program.cs            # Application setup
│
└── SmsService.Tests/         # Automated tests (xUnit)
├── MessageRepositoryTests.cs
└── FakeSmsProviderTests.cs
---

## 📌 Technologies Used

- **ASP.NET Core (.NET 8)**
- **Entity Framework Core 8.0.33**
- **SQLite**
- **Swagger / OpenAPI**
- **xUnit**
- **EF Core InMemory Provider**

---

## 📌 Installation & Running

### 1. Clone the repository

```bash
git clone https://github.com/TalyaTr/SmsService.git
cd SmsService
dotnet restore
dotnet ef database update
dotnet run
cd SmsService.Tests
dotnet test

Assumptions
The following assumptions were made during development:

The SMS provider is treated as an external system, so a fake provider is used for simulation.

Message status can only be: Pending, Sent, or Failed.

Phone numbers must follow the Israeli format.

Maximum message length is 160 characters.

SQLite is used for simplicity and portability.

Automated tests use the EF Core InMemory provider to avoid dependency on a real database.

Business logic for sending SMS is separated from the controller for maintainability and future extensibility.

Design Considerations
Simplicity & Stability  
SQLite allows easy local development without external dependencies.

Separation of Concerns  
The project is divided into layers (Controller, Repository, Provider) to improve maintainability.

Testability  
Using InMemory database enables fast and isolated unit tests.

Extensibility  
The FakeSmsProvider can be replaced with a real SMS provider without changing business logic.

Dependency Injection  
DI enables clean architecture, easy testing, and clear separation between interfaces and implementations.

פשטות ויציבות — שימוש ב‑SQLite מאפשר הרצה ללא התקנות חיצוניות.

הפרדת אחריות — חלוקה לשכבות (Controller / Repository / Provider) מאפשרת תחזוקה קלה.

בדיקות אוטומטיות — שימוש ב‑InMemory מאפשר בדיקות מהירות ללא תלות במסד נתונים.

הרחבה עתידית — ניתן להחליף את FakeSmsProvider ב‑API אמיתי ללא שינוי בקוד הלוגי.

שימוש ב‑DI — מאפשר הזרקת תלות, בדיקות יחידה, והפרדה בין ממשק למימוש.


Author
Talya  
2026