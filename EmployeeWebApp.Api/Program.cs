using EmployeeWebApp.Application.Companies.AddCompany;
using EmployeeWebApp.Domain.Extensions;
using EmployeeWebApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.MigrateDatabase(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddCompanyCommand>());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.Run();