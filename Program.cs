using Microsoft.EntityFrameworkCore;
using LmsApi.Models;
using LmsApi.Data;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BookContext>(opt =>
    opt.UseInMemoryDatabase("BookList"));
builder.Services.AddDbContext<LmsContext>(opt =>
    opt.UseInMemoryDatabase("Library"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed DB with test data
var scope = app.Services.CreateScope();
var lmscontext = scope.ServiceProvider.GetRequiredService<LmsContext>();
MockData.Initializer(lmscontext);

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
