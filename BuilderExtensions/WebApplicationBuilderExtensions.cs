using System.Data;
using System.Data.SqlClient;
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
                conn.Open();
                return conn;
            });
            return builder;
        }
    }
}
