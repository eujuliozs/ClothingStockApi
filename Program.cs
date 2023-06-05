using ClothingApi.BuilderExtensions;
using ClothingApi.Data;
using System.Data.SqlClient;
using System.Data;
using ClothingApi.Extensions;
using ClothingApi.Validations;

namespace ClothingApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
         
        builder.SetDatabase();



        builder.AddJwtBearer();

        builder.Services.AddControllers();

        var app = builder.Build();

        app.LoginEndPoints();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}