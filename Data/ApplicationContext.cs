using System.Data;

namespace ClothingApi.Data
{
    public class ApplicationContext
    {
        public delegate Task<IDbConnection> GetConnection();
    }
}
