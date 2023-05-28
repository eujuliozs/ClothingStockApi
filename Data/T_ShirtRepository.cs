using ClothingApi.Model;
using Dapper.Contrib.Extensions;
using System.Data;
using System.Reflection;

namespace ClothingApi.Data
{
    public class T_ShirtRepository : Repository
    {
        public T_ShirtRepository(IDbConnection conn) : base(conn)
        {
        }
        public async Task PatchAsync(int id, T_Shirt t_Shirt)
        {
            T_Shirt DatabaseObj = GetByIdAsync<T_Shirt>(id).Result;

            PropertyInfo[] DatabaseObj_reflection = DatabaseObj.GetType().GetProperties();

            PropertyInfo[] InputObj_reflection = t_Shirt.GetType().GetProperties();

            for(int i = 0;i < InputObj_reflection.Length; i++)
            {
                if (InputObj_reflection[i].GetValue(t_Shirt) != null)
                {
                    PropertyInfo DatabaseObjprop = Array.Find(DatabaseObj_reflection, prop => prop.Name == InputObj_reflection[i].Name);

                    object valorPropriedadeOrigem = InputObj_reflection[i].GetValue(t_Shirt);
                    DatabaseObjprop.SetValue(DatabaseObj, valorPropriedadeOrigem);
                }
            }
            DatabaseObj.Id = id;
            await connection.UpdateAsync(DatabaseObj);
        }
    }
}
