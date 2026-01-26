using Usuario.API.Services;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<UserService>();//necessario para inicializar lembrar sempre

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection(); API tentou redirecionar HTTP → HTTPS, mas não sabe qual porta HTTPS usar, então avisa (warn) e segue a vida.

app.UseAuthorization();

app.MapControllers();

app.Run();
