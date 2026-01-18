# 📚 Library Automation Web Application

A modern, user-friendly library management system. Developed with ASP.NET Core MVC.

## 🚀 Features

- **Dashboard**: Real-time statistics (Total Books, Members, Active Loans, Overdue Books)
- **Book Management**: Add, edit, delete books and manage copies
- **Member Management**: Member registration and listing
- **Loan Operations**: Book lending and return processing
- **Reports**: Most read books, member-based loan reports

## 🛠️ Technology Stack

| Layer | Technology |
|-------|------------|
| Backend | C# ASP.NET Core MVC |
| ORM | Entity Framework Core (Database First) |
| Frontend | Bootstrap 5, DataTables |
| Database | Microsoft SQL Server |
| Testing | xUnit |

## 📋 Requirements

- .NET 8.0 SDK or higher
- SQL Server (LocalDB, Express, or Full)
- Visual Studio 2022 or VS Code

## ⚙️ Installation

### 1. Clone the Project (Optional)

If using Git:
```bash
git clone <repository-url>
cd KutuphaneOtomasyonu
```

### 2. Create the Database ⚠️ IMPORTANT

Open SQL Server Management Studio (SSMS) or Azure Data Studio and run the `Database/setup_database.sql` file:

**Steps:**
1. Open SSMS and connect to SQL Server
2. Open `Database/setup_database.sql` via `File > Open > File...`
3. Press the `Execute` (F5) button
4. Wait until you see the "DATABASE SETUP COMPLETED!" message

**This script creates:**
- `KutuphaneDB` database
- 5 tables (books, copies, members, loans, loan_history)
- 7 stored procedures
- Sample data (10 books, 7 members, 13 copies)

### 3. Check Connection String

Edit the connection string in `appsettings.json` according to your environment:

**Windows Authentication (Default):**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=KutuphaneDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
```

**SQL Server Authentication:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=KutuphaneDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
```

### 4. Build and Run the Project

```bash
cd KutuphaneOtomasyonu
dotnet restore
dotnet build
dotnet run --project KutuphaneOtomasyonu.Web
```

The application will run at the following address by default:
- http://localhost:5231 (or check the console for the address)

## 🧪 Run Tests

```bash
dotnet test
```

## 📁 Project Structure

```
KutuphaneOtomasyonu/
├── Database/
│   └── setup_database.sql      # Database setup script
├── KutuphaneOtomasyonu.Web/
│   ├── Controllers/            # MVC Controllers
│   │   ├── HomeController.cs
│   │   ├── BooksController.cs
│   │   ├── MembersController.cs
│   │   ├── LoansController.cs
│   │   └── ReportsController.cs
│   ├── Models/
│   │   ├── Entities/           # EF Core Entities
│   │   ├── ViewModels/         # View Models
│   │   └── KutuphaneDbContext.cs
│   ├── Services/               # Business Logic Layer
│   ├── Views/                  # Razor Views
│   └── wwwroot/                # Static files
├── KutuphaneOtomasyonu.Tests/  # Unit Tests
├── .gitignore
└── README.md
```

## 🔧 Stored Procedures

The application uses the following stored procedures:

| Procedure | Description |
|-----------|-------------|
| `sp_AddBook` | Add new book |
| `sp_UpdateBook` | Update book |
| `sp_DeleteBook` | Delete book |
| `sp_AddCopy` | Add book copy |
| `sp_AddMember` | Add new member |
| `sp_LoanBook` | Loan book |
| `sp_ReturnBook` | Return book |

## 📊 Database Schema

```
┌─────────────┐     ┌─────────────┐     ┌─────────────┐
│   books     │────<│   copies    │────<│    loans    │
├─────────────┤     ├─────────────┤     ├─────────────┤
│ book_id     │     │ copy_id     │     │ loan_id     │
│ isbn        │     │ book_id     │     │ copy_id     │
│ title       │     │ shelf_loc   │     │ member_id   │
│ author      │     │ status      │     │ loaned_at   │
│ ...         │     │ ...         │     │ due_at      │
└─────────────┘     └─────────────┘     │ returned_at │
                                        └──────┬──────┘
                    ┌─────────────┐            │
                    │   members   │────────────┘
                    ├─────────────┤
                    │ member_id   │
                    │ full_name   │
                    │ email       │
                    │ ...         │
                    └─────────────┘
```

## 🐛 Common Errors

### "Invalid object name 'books'" Error
This error means the database has not been created. Run the `Database/setup_database.sql` file in SQL Server.

### "Cannot open database 'KutuphaneDB'" Error
Make sure the SQL Server service is running and the connection string is correct.

## 👥 Team

- İbrahim Ünal
- Burak Çelik

## 📄 License

This project was developed for educational purposes.

---

**DBMS Project - 2025**
