using CRUDify_API.Data;
using CRUDify_API.Data.Repositories.Interfaces;
using CRUDify_API.Data.Repositories;
using CRUDify_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // React app's URL
              .AllowAnyMethod()                    // Allow all HTTP methods (GET, POST, etc.)
              .AllowAnyHeader()                    // Allow any headers
              .AllowCredentials();                 // Allow cookies/auth tokens
    });
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Use CORS
app.UseCors("AllowReactApp");

app.MapControllers();

app.Run();
