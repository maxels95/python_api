using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using python_api.Data;
using python_api.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PythonCcContext>(options =>
    options.UseSqlite("DefaultConnection"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "python_api", Version = "v1" });
});
builder.Services.AddScoped<PythonService>();
builder.Services.AddScoped<IReadingRepository, ReadingRepository>();
builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();


 app.UseSwagger();
 app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "python_api V1");
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
