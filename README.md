# Library Management System

A console-based library management application built with C# and .NET. It supports member registration, catalog search, book borrowing and returns, and overdue tracking—with separate membership tiers and in-memory data storage.

## Features

- **Member management** — Register regular or premium members with duplicate email validation
- **Catalog search** — Find books and members by title or name (case-insensitive)
- **Book inventory** — Add books and view currently available titles
- **Borrowing workflow** — Borrow and return books with availability and limit checks
- **Borrow history** — View a member's full borrowing record, including return status
- **Late return report** — Identify active borrows that exceed the member's loan period

## Tech Stack

| Component | Details |
|-----------|---------|
| Language | C# |
| Runtime | .NET 10.0 |
| Application type | Console |
| Persistence | In-memory (mock data loaded at startup) |

## Getting Started

### Prerequisites

- [.NET SDK 10.0](https://dotnet.microsoft.com/download) or later

### Build

```bash
dotnet build "Library Management System.slnx"
```

### Run

```bash
dotnet run --project "Library Management System/Library Management System.csproj"
```

On launch, the application loads sample members, books, and borrow records so you can explore features immediately.

## Usage

When the application starts, choose an option from the main menu:

| Option | Action |
|--------|--------|
| 1 | Register a new member (regular or premium) |
| 2 | Search the catalog by book title or member name |
| 3 | View all available books |
| 4 | View borrowing history for a member |
| 5 | Generate a late return report |
| 6 | Add a new book to the catalog |
| 7 | Borrow a book (requires member ID and book ID) |
| 8 | Return a book (requires book ID) |

## Membership Tiers

| Tier | Max books | Loan period |
|------|-----------|-------------|
| Regular | 5 | 14 days |
| Premium | 10 | 30 days |

Borrow limits and due dates are enforced automatically when a member attempts to borrow a book.

## Project Structure

```
Library-Management-System/
├── Library Management System/
│   ├── Interfaces/
│   │   └── ISearchable.cs       # Search contract for books and members
│   ├── models/
│   │   ├── Book.cs              # Book entity
│   │   ├── BorrowRecord.cs      # Borrow/return transaction record
│   │   ├── LibraryItem.cs       # Base class for library items
│   │   ├── Member.cs            # Abstract member base class
│   │   ├── PremiumMember.cs     # Premium tier implementation
│   │   └── RegularMember.cs     # Regular tier implementation
│   ├── Services/
│   │   └── LibraryService.cs    # Core business logic and menu handling
│   └── Program.cs               # Application entry point
└── Library Management System.slnx
```

## Design Highlights

- **Object-oriented design** — `Member` and `LibraryItem` abstract base classes with concrete implementations for each tier and item type
- **Polymorphism** — `RegularMember` and `PremiumMember` override borrow limits and loan periods
- **Interface segregation** — `ISearchable` provides a unified search contract across books and members
- **Reflection-based metadata** — `getInfo()` / `GetInfo()` use reflection to expose object properties for display without manual field mapping

## License

This project is provided as-is for educational and demonstration purposes.
