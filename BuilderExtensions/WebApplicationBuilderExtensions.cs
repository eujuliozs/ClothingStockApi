using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace ClothingApi.BuilderExtensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder SetDatabase(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddScoped<IDbConnection>(provider =>
            {
                var conn = new SqlConnection(connectionString);
                return conn;
            });
            return builder;
        }
    }
}
