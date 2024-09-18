using NsUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseHttpsRedirection();

List<User> users = new List<User>();

app.MapGet("/users", () =>
{
    return users;
});

app.MapGet("/users/{Id}", (Guid id
) =>
{
    var user = users.FirstOrDefault(user => user.Id == id);
    return Results.Ok(user);
});

app.MapPost("/users", (User newUser) =>
{

    users.Add(newUser);
    return Results.Created();
});

app.Run();

