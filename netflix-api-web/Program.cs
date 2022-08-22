

using netflix_api_application;
using netflix_api_persistance;
using netflix_api_shared;
using netflix_api_web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistanceInfraestructure(builder.Configuration);
builder.Services.AddSharedInfrasctructure(builder.Configuration);

// Referecnia a servicios de la capa de aplicación.
builder.Services.AddApplicationLayer();
builder.Services.AddControllers();

// versionamento de la API.
builder.Services.AddApiVersioningExtension();

builder.Services.AddCors();
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

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();
app.UseErrorHandlingMiddleware();
app.MapControllers();

app.Run();
