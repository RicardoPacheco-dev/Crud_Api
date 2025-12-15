using CRUD_API.AppDataContext;
using CRUD_API.Middleware;
using CRUD_API.Models;
using CRUD_API.Services;
using CRUD_API.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<CRUD_APIDbContext>();
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddLogging();
builder.Services.AddScoped<IMedicamentServices, MedicamentServices>();
var app = builder.Build();

{
    using var scope = app.Services.CreateScope(); 
    var context = scope.ServiceProvider; 
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();