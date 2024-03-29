using CoreWebAPI;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.EFCore;
using Repository.Generic;
using Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TestdbContext>(options => options.UseSqlServer("Data Source=RAKESH;Initial Catalog=TESTDB;Persist Security Info=True;User ID=sa;Password=admin123;Encrypt=True;Trust Server Certificate=True"));

DependencyInjection.AddClassesMatchingInterfaces(builder.Services, "CoreWebAPI");
DependencyInjection.AddClassesMatchingInterfaces(builder.Services, "Repository");


builder.Services.AddAutoMapper(typeof(MapperConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware(typeof(MiddleWareConfig));

app.MapControllers();

app.Run();
