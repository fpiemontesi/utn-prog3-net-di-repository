using DependencyInjection.Context;
using DependencyInjection.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<ICountryRepository, InMemoryRepository>(); // instancia unica
//builder.Services.AddScoped<ICountryRepository, FileCountryRepository>(); // una instancia por ambito, en caso de un controlador ser�a por request
builder.Services.AddTransient<ICountryRepository, DbCountryRepository>(); // una instancia cada vez que es requerida

builder.Services.AddDbContext<CountryDbContext>((context) =>
{
    context.UseSqlServer(builder.Configuration.GetConnectionString("CountryDb"));
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
