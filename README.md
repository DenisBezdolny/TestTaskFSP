# Test Task: User Management Application

## Overview

This project is a sample ASP.NET MVC application for managing users, developed as a test assignment. The project demonstrates the following capabilities:

- **API Design:** A web service that handles CRUD (Create, Read, Update, Delete) operations for a "User" entity and returns JSON data.
- **Layered Architecture:** The project follows a clean architecture approach by separating Domain, Business Logic (BLL), Infrastructure, and Presentation layers.
- **Frontend Interactivity:** An HTML page using responsive CSS (with Flexbox) and native JavaScript to dynamically display, add, edit, and delete users.
- **Data Storage Simulation:** Instead of using a full database, an in-memory collection (generic repository) is used to store and manage user data. This approach simplifies deployment and testing.

## Architecture

### Domain Layer
- **Entities/User.cs:** Contains the `User` class with the following properties:
  - `Id` (unique identifier)
  - `FirstName`
  - `LastName`
  - `Age`
  - `Email`

### Infrastructure Layer
- **Repositories/Repository<TEntity>.cs:**  
  A generic in-memory repository that implements basic CRUD operations.  
  The repository uses a `ConcurrentDictionary<Guid, TEntity>` to simulate data storage.
- **Dependency Injection:**  
  The repository is registered as a Singleton to ensure that user data persists between HTTP requests.

### Business Logic Layer (BLL)
- **Services/UserService.cs:**  
  Implements the `IUserService` interface, which encapsulates user-related operations (Get, Create, Update, Delete) by interacting with the repository.

### Presentation Layer
- **API Controller (UserController.cs):**  
  Provides the following endpoints:
  - **GET /api/user:** Retrieves all users in JSON format.
  - **GET /api/user/{id}:** Retrieves a user by ID.
  - **POST /api/user:** Adds a new user.
  - **PUT /api/user/{id}:** Updates an existing user.
  - **DELETE /api/user/{id}:** Deletes a user.

  The controller is decorated with `[ApiController]`, which automatically handles JSON serialization.

- **Razor View (e.g., Index.cshtml):**  
  Contains the HTML markup for:
  - A user addition form.
  - A responsive table (with columns: ID, First Name, Last Name, Age, Email, Actions) to display user data.
  - A hidden editing section that appears when editing is required.
  
  The view uses Flexbox-based CSS for responsiveness and integrates with a native JavaScript file (`user.js`) that calls the API endpoints.

- **JavaScript (wwwroot/js/user.js):**  
  Implements functions for:
  - Loading user data from the API and rendering the table.
  - Adding a new user.
  - Deleting a user.
  - Editing a user (fetching existing data and submitting updates).
  
  All operations are performed asynchronously using the Fetch API, and the table is dynamically updated after each operation.

## Technologies Used

- **C#** and **ASP.NET MVC / ASP.NET Core**
- **In-Memory Data Storage** (for rapid testing; no full database is required)
- **HTML/CSS** with Flexbox for responsive design
- **Native JavaScript** (ES6+) for AJAX calls and dynamic DOM manipulation

## Project Structure
```pgsql
Solution
│
├── TestTask (MVC Application)
│   ├── Controllers
│   │   └── UserController.cs
│   ├── Views
│   │   ├── Home
│   │   │   └── Index.cshtml  (or a dedicated Users view)
│   │   └── Shared
│   │       └── _Layout.cshtml
│   ├── wwwroot
│   │   ├── css
│   │   │   └── site.css  (plus any additional style files)
│   │   └── js
│   │       └── user.js
│   └── Program.cs / Startup.cs (DI & configuration)
│
├── TestTask.Domain
│   └── Entities
│       └── User.cs
│   └── Interfaces
│       └── IUserService.cs (in BLL folder) and IRepository.cs (in Repositories folder)
│
├── TestTask.Bll
│   └── Services
│       └── UserService.cs
│
├── TestTask.Infrastructure
    └── Repositories
        └── Repository<TEntity>.cs
```


## How to Run

1. **Clone the repository** from GitHub.
2. Open the solution in Visual Studio.
3. Build the solution.
4. Run the project (F5 or Ctrl+F5) – the application will start with minimal setup.
5. Navigate to the appropriate page (e.g., Home/Users or Home/Index) to view and interact with the user list.
6. Use the form to add, edit, or delete users. The table will update dynamically.

## Conclusion

This project demonstrates the ability to design and implement a layered architecture, create a functional web API using ASP.NET, and integrate a responsive user interface with HTML, CSS, and JavaScript.
