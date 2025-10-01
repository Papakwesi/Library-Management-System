 📚 Library Management System

A simple **ASP.NET Core MVC** application that manages library books and borrowing records.
This project was built to practice **Entity Framework Core, ASP.NET Identity, role-based authentication, and CRUD operations**.

---

🚀 Features

* **Authentication & Roles**

  * Admin → manage books & view all borrow records
  * Member → borrow & return books

* **Book Management (CRUD)**

  * Add, edit, delete, and list books
  * Track quantity & availability

* **Borrowing System**

  * Members can borrow and return books
  * Stock updates automatically
  * Borrow history tracking

* **Database Seeding**

  * Default admin account
  * Preloaded books and roles

---

🛠️ Tech Stack

* **Framework:** ASP.NET Core MVC (.NET 8 / 9)
* **Database:** SQL Server with Entity Framework Core
* **Authentication:** ASP.NET Identity (with roles)
* **UI:** Bootstrap (or Tailwind, depending on your final choice)

---

📂 Project Structure

```
LibraryManagement/
│── Controllers/        # MVC controllers
│── Models/             # Book, BorrowRecord, ApplicationUser, etc.
│── Views/              # Razor views
│── Data/               # DbContext & DbInitializer
│── wwwroot/            # Static files (CSS, JS, images)
│── Program.cs          # Application startup
```

---

⚡ Getting Started

Prerequisites

* .NET 8 or later
* SQL Server (LocalDB or full)
* Visual Studio / VS Code

Installation

```bash
# Clone repository
git clone https://github.com/your-username/LibraryManagement.git

# Navigate to project
cd LibraryManagement

# Restore dependencies
dotnet restore

# Apply migrations
dotnet ef database update

# Run the project
dotnet run
```

---

👥 Default Accounts

* **SuperAdmin**
* **Admin**
* **Member**

---

