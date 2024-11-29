using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Solvace.TechCase.API.Middleware;
using Solvace.TechCase.Domain.Interfaces;
using Solvace.TechCase.Repository.Contexts;
using Solvace.TechCase.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DefaultContext>(
    x => x.UseSqlite(builder.Configuration.GetConnectionString("defaultConnection"))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
    );

builder.Services.AddScoped<IActionPlanService, ActionPlanService>();
builder.Services.AddScoped<IProductServices, ProductService>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();




app.Run();

