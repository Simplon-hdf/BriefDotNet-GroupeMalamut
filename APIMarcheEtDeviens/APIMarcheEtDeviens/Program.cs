using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Repository;
using Microsoft.EntityFrameworkCore;
using APIMarcheEtDeviens.Models;
using MySql.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IController<int, Participer>, ParticiperService>();
builder.Services.AddScoped<IController<Guid, Media>, MediaService>();
builder.Services.AddScoped<IController<int, Role>, RoleService>();
builder.Services.AddScoped<IController<Guid, Randonnee>, RandonneeService>();
builder.Services.AddScoped<IController<Guid, Randonneur>, RandonneurService>();
builder.Services.AddScoped<IController<Guid, Pensee>, PenseeService>();

builder.Services.AddDbContext<DataContext>(options =>

{
	options.UseMySQL(builder.Configuration.GetConnectionString("DefaultValue"));
});

builder.Services.AddAuthentication();

builder.Services.AddEntityApiFramework;
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
