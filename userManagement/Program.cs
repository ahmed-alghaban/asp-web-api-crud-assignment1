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

});

app.MapPost("/users" , (User newUser){

    users.Add(newUser);
    return Results.Created();
});

app.Run();

