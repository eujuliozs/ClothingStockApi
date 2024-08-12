using Dapper.Contrib.Extensions;

namespace ClothingApi.Model;

public class Short : Clothes 
{
    [Key]
    public int Id {  get; set; }
}
