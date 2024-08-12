using ClothingApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;
using ClothingApi.Data;
 
namespace ClothingApi.BuilderExtensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder SetDatabase(this WebApplicationBuilder builder)
        {
            try
            {
                string connectionString = builder.Configuration.GetConnectionString("Default");
                builder.Services.AddScoped<IDbConnection>(provider =>
                {
                    var conn = new SqlConnection(connectionString); 
                    conn.Open();

                    return conn;
                });
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }

            builder.Services.AddScoped<Repository>();
            return builder;
        }
        public static WebApplicationBuilder AddJwtBearer(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
            builder.Services.AddSingleton<ITokenService>(new TokenService());
            builder.Services.AddAuthorization();
            return builder;
        }

    }
}
