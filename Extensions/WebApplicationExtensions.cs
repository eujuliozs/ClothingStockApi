using ClothingApi.Model;
using ClothingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClothingApi.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication LoginEndPoints(this WebApplication app)
        {
            app.MapPost("api/Login", ([FromServices]ITokenService tokenService, UserModel user) =>
            {

                if (user.UserName == "Julio" && user.Password == "1234")
                {
                    string token = tokenService.GenerateToken(app.Configuration["Jwt:Key"],
                        app.Configuration["Jwt:Issuer"],
                        app.Configuration["Jwt:Audience"],
                        user);
                    return Results.Ok(new {Token=token});
                }
                return Results.BadRequest();  
            }).AllowAnonymous();

            return app;
        }
    }
}
