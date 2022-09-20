using Microsoft.AspNetCore.Mvc;
using MovieRatingsMinimalAPI;
using MovieRatingsMinimalAPI.Models;
using MovieRatingsMinimalAPI.Services;
using MovieRatingsMinimalAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var connectionStringMariaDB = builder.Configuration.GetConnectionString("DefaultMariaDBConnection");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    builder =>
    {
        builder.WithOrigins("https://localhost:7060", "https://blroberts.azurewebsites.net")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});
builder.Services.AddScoped<IMariaDBService, MariaDBService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/movies/list", ([FromServices] IMariaDBService service)
    => service.LoadData<MovieRating, dynamic>(MovieQueryHelpers.GetAllMovieRatings(), new { }, connectionStringMariaDB));

app.MapPost("/movies/create", ([FromBody] MovieRating movieRating, [FromServices] IMariaDBService service)
    => service.SaveData(MovieQueryHelpers.InsertMovieRatings(), movieRating, connectionStringMariaDB));

app.Run();
