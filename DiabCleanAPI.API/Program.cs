using DiabCleanAPI;
using DiabCleanAPI.Application.Commands.CompanyCommands;
using DiabCleanAPI.DiabCleanAPI.Application.Commands.EmployeeCommands;
using DiabCleanAPI.DiabCleanAPI.Application.DTOs;
using DiabCleanAPI.DiabCleanAPI.Application.Repositories;
using DiabCleanAPI.DiabCleanAPI.Infrastructure.Data.RepositoriesImplementation;
using DiabCleanAPI.Domain.Validation;
using FluentValidation;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(o =>
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<AppDBContext>();

builder.Services.AddTransient<IValidator<Employee>, EmployeeValidator>();
builder.Services.AddTransient<IValidator<Company>, CompanyValidator>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateCompanyCommand)));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));

app.UseAuthorization();

app.MapControllers();

app.Run();
