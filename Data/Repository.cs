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

        public async Task PatchAsync<T>(int id, T Entry_Object) where T : Entity
        {
            //acha a entidade do id passado no banco de dados
            T Database_Entity = GetByIdAsync<T>(id).Result;

            //transforma a entidade do banco de dados numa array do tipo propertyInfo
            PropertyInfo[] DestinyProperties = Database_Entity.GetType().GetProperties();

            //transforma a entidade de origem(input) numa array do tipo propertyInfo
            PropertyInfo[] OriginProperties = Entry_Object.GetType().GetProperties();

            for (int i = 0; i < OriginProperties.Length; i++)
            {
                if (OriginProperties[i].GetValue(Entry_Object) != null)
                {
                    //acha uma propriedade com nome que combina na entidade destino e na entidade origem
                    PropertyInfo MatchingOriginProperty = Array.Find(DestinyProperties, prop => prop.Name == OriginProperties[i].Name);

                    object OriginPropertyValue = OriginProperties[i].GetValue(Entry_Object);
                    //
                    if(MatchingOriginProperty.GetValue(Entry_Object) != null)
                    {
                        MatchingOriginProperty.SetValue(Database_Entity, OriginPropertyValue);
                    }
                }
            }
            
            Database_Entity.Id = id;
            await connection.UpdateAsync(Database_Entity);
            connection.Close();
        }
        public async Task DeleteAsync<T>(T obj)  where T : class
        {
            await connection.DeleteAsync<T>(obj);
        }

    }
    
}
