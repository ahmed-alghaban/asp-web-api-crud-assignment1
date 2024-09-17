### **Assignment: User Management API with CRUD Operations**

The goal of this assignment is to help you practice building a basic User Management API using ASP.NET Core. You will create endpoints to manage users with basic CRUD (Create, Read, Update, Delete) operations.

### **Requirements**

1. **Create a User Model**:
   - The user should have the following properties:
     - `Id` (Guid) - Unique identifier for each user.
     - `FirstName` (string) - User's first name.
     - `LastName` (string) - User's last name.
     - `Email` (string) - User's email address.
     - `CreatedAt` (DateTime) - The date when the user was created.

2. **Create CRUD Endpoints**:
   - **GET** `/users`: Retrieve a list of all users with optional pagination (e.g., `pageNumber` and `pageSize`).
   - **GET** `/users/{id}`: Retrieve a specific user by their unique `Id`.
   - **POST** `/users`: Create a new user.
   - **PUT** `/users/{id}`: Update an existing user's details.
   - **DELETE** `/users/{id}`: Delete a user by their unique `Id`.

3. **Input Validation**:
   - Ensure that `Email` is valid and unique.
   - Ensure that `FirstName` and `LastName` are not empty.

4. **Responses**:
   - Return appropriate HTTP status codes:
     - `200 OK` for successful operations.
     - `201 Created` for successfully created users.
     - `404 Not Found` if the user is not found.
     - `400 Bad Request` for invalid inputs.
