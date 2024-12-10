using System.Text.Json;
using System.Text.Json.Serialization;
using Api.DbContexts;
using Api.Middleware;
using Api.Services;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(options => {
    options.LoggingFields = HttpLoggingFields.All;
});


builder.Services.AddDbContext<TravelPlanningContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITripPlanningService, TripPlanningService>();


var app = builder.Build();

app.UseHttpLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestLoggingMiddleware>();  
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
