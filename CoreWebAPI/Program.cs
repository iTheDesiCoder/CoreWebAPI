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
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IStockRepository), typeof(StockRepository));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
