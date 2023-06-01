using ClothingApi.Model;

namespace ClothingApi.Services
{
    public interface ITokenService
    {
        public string GenerateToken(string key, string issuer, string audience, UserModel userModel);
    }
}
