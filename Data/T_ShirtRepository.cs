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
            T_Shirt obj = GetByIdAsync<T_Shirt>(id).Result;
            PropertyInfo[] properties = t_Shirt.GetType().GetProperties();
            int cont = 0;
            foreach (PropertyInfo prop in properties)
            {
                cont++;
                if (prop.GetValue(t_Shirt) != null)
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
                    if (cont == 6)
                    {
                        obj.ImageUrl = prop.GetValue(t_Shirt)?.ToString();
                    }
                }
            }

            obj.Id = id;
            await connection.UpdateAsync<T_Shirt>(obj);
            await Console.Out.WriteLineAsync(obj.ToString());
            Console.WriteLine(obj.ToString());
            connection.Close();

        }
    }
}
