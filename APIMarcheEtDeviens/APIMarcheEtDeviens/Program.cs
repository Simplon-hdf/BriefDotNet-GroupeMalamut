using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Repository;
using Microsoft.EntityFrameworkCore;
using APIMarcheEtDeviens.Models;
using MySql.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IController<int, Role>, RoleService>();
builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseMySQL(builder.Configuration.GetConnectionString("DefaultValue"));
});

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
