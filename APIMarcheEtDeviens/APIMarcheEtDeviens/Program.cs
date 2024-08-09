using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Repository;
using Microsoft.EntityFrameworkCore;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Services;
using AutoMapper;
using APIMarcheEtDeviens.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IController<int, Participer>, ParticiperService>();
builder.Services.AddScoped<IController<Guid, MediaDto>, MediaService>();
builder.Services.AddScoped<IController<int, RoleDto>, RoleService>();
builder.Services.AddScoped<IController<Guid, RandonneeDto>, RandonneeService>();
builder.Services.AddScoped<IController<Guid, RandonneurDTO>, RandonneurService>();
builder.Services.AddScoped<IController<Guid, PenseeDto>, PenseeService>();

builder.Services.AddDbContext<DataContext>(options =>

{
	options.UseMySQL(builder.Configuration.GetConnectionString("DefaultValue"));
});

builder.Services.AddAuthentication();

//builder.Services.AddEntityApiFramework;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(Program).Assembly);
var config = new MapperConfiguration(cfg => {
	cfg.AddProfile<AutomapperProfile>();
});

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
