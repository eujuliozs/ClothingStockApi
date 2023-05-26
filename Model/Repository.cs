using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;

namespace ClothingApi.Model
{
    public class Repository 
    {
        private readonly IDbConnection connection;

        public Repository(IDbConnection conn)
        {
            connection = conn;

        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class 
        {
            IEnumerable<T> objects = await connection.GetAllAsync<T>();
            connection.Close();
            return objects;
    
        }

        public async Task AddAsync<T>(T obj) where T : class
        {
            await connection.InsertAsync(obj);
            connection.Close();
        }
        
        public async Task PatchAsync<T>(int id, T t_Shirt) where T : class
        {
            T obj = await connection.GetAsync<T>(id);
            PropertyInfo[] properties = t_Shirt.GetType().GetProperties();

            foreach (PropertyInfo prop in properties) 
            {
                if (prop != null) 
                {
                    
                }
            }
        }
    }
}
