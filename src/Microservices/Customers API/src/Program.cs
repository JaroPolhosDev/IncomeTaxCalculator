using Customers_API.DataSource;
using Customers_API.Models;
using Customers_API.Repositories;
using Customers_API.Services;
using Customers_API;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add controllers to the container.

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddTransient<ICustomersService,CustomersService>();
builder.Services.AddTransient<ICustomersRepository,CustomersRepository>();
builder.Services.AddTransient<ICustomersDataSource,CustomersDataSource>();
builder.Services.AddTransient<IValidator<Customer>, CustomerValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
