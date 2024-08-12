using System.Runtime.CompilerServices;
using Dapper.Contrib.Extensions;

namespace ClothingApi.Model;

public class T_Shirt : Clothes 
{
    [Key]
    public int Id { get; set; }
}
