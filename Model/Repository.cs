using Dapper.Contrib.Extensions;
using System.Data;

namespace ClothingApi.Model
{
    public class Repository 
    {
        private readonly IDbConnection connection;

        public Repository(IDbConnection conn)
        {
            connection = conn;

        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class 
        {
            IEnumerable<T> objects = await connection.GetAllAsync<T>();
            connection.Close();
            return objects;
    
        }

        public async Task Add<T>(T obj) where T : class
        {
            await connection.InsertAsync(obj);
            connection.Close();
        }
    }
}
