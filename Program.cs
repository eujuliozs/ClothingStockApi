using ClothingApi.BuilderExtensions;
using ClothingApi.Data;
using ClothingApi.Model;
using System.Data.SqlClient;
using System.Data;

namespace ClothingApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
         
        builder.SetDatabase();

        builder.Services.AddScoped<Repository>();

        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}