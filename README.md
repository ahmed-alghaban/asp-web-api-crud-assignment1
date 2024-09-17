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
```csharp
   var builder = WebApplication.CreateBuilder(args);

   var app = builder.Build();
   
   app.UseHttpsRedirection();
   
   List<User> users = new List<User>();
   
   // GET: /users => return all the users
   app.MapGet("/users", (int page, int limit) =>
   {
       Console.WriteLine($"{page}");
   
       // pagination
       int skip = (page - 1) * limit;
       var paginatedUsers = users.Skip(skip).Take(limit);
       return Results.Ok(paginatedUsers);
   });
   // users?page=2&limit=3
   
   // GET: /users/{id} => return single users
   app.MapGet("/users/{id}", (Guid id) =>
   {
       var user = users.FirstOrDefault(user => user.Id == id);
       return Results.Ok(user);
   });
   
   // POST: /users => create the user
   app.MapPost("/users", (User newUser) =>
   {
       // User already exist?
       // FirstName and LastName can not be or null 
       // is Email valid?
   
       newUser.Id = Guid.NewGuid();
       newUser.CreatedAt = DateTime.Now;
       users.Add(newUser);
       return Results.Created("user is created", newUser);
   });
   
   // PUT: /users/{id} => update the user
   app.MapPut("/users/{id}", (Guid id, User updatedUser) =>
   {
       var user = users.FirstOrDefault(user => user.Id == id);
       if (user == null)
       {
           return Results.NotFound($"User with this id {id} does not exists.");
       }
       user.FirstName = updatedUser.FirstName ?? user.FirstName;
       user.LastName = updatedUser.LastName ?? user.LastName;
       user.Email = updatedUser.Email ?? user.Email;
   
       return Results.Ok(user);
   });
   
   // DELETE: /users/{id} => delete the user
   app.MapDelete("/users/{id}", () =>
   {
       return "deleted single user";
   });
   
   app.Run();
   
   class User
   {
       public Guid Id { get; set; }
       public string? FirstName { get; set; }
       public string? LastName { get; set; }
       public string? Email { get; set; }
       public DateTime CreatedAt { get; set; }
   }

```
