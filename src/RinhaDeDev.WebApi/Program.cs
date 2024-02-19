using RinhaDeDev.Application;
using RinhaDeDev.Domain;
using RinhaDeDev.Infrastructure;
using RinhaDeDev.WebApi;
using RinhaDeDev.WebApi.Extensions;
using RinhaDeDev.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddWebApiServices()
    .AddInfrastructureServices()
    .AddApplicationServices()
    .AddDomainServices();

var app = builder.Build();

await app.MigrateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<HttpErrorResponseMiddleware>();

app.UseHttpsRedirection();

app.Run();