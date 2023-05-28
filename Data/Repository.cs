using ClothingApi.Model;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;

namespace ClothingApi.Data
{
    public class Repository
    {
        protected readonly IDbConnection connection;

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

        public async Task<T> GetByIdAsync<T>(int id) where T : class
        {
            return await connection.GetAsync<T>(id);

        }

        public async Task PatchAsync<T>(int id, T t_Shirt) where T : Clothes
        {
            T obj = GetByIdAsync<T>(id).Result;
            PropertyInfo[] properties = t_Shirt.GetType().GetProperties();
            int cont = 0;
            foreach (PropertyInfo prop in properties)
            {
                cont++;
                if (prop != null)
                {
                    if (cont == 1)
                    {
                        obj.Id = (int)prop.GetValue(t_Shirt);
                    }
                    if (cont == 2)
                    {
                        var Foreign_objPROP = prop.GetValue(t_Shirt).ToString();
                        obj.Name = Foreign_objPROP;
                    }
                    if (cont == 3)
                    {
                        obj.size = (int)prop.GetValue(t_Shirt);
                    }
                    if (cont == 4)
                    {
                        obj.color = prop.GetValue(t_Shirt)?.ToString();
                    }
                    if (cont == 5)
                    {
                        obj.Description = prop.GetValue(t_Shirt)?.ToString();
                    }
                    if (cont == 5)
                    {
                        obj.ImageUrl = prop.GetValue(t_Shirt)?.ToString();
                    }
                }
            }
            await connection.UpdateAsync(obj);
            await Console.Out.WriteLineAsync(obj.ToString());
            Console.WriteLine(obj.ToString());
            connection.Close();
        }
    }
}
