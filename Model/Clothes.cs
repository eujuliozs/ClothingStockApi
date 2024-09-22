using ClothingApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace ClothingApi.Model;

public class Clothes : Entity
{
    public string? Name { get; set; }
    public int? Stock { get; set; }
    public string? Color { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? Type { get; set; }

    [SizeValidation]
    public string? Size { get; set; }

    public override string ToString()
    {
        return $"ID :{Id} \n" +
            $"Name : {Name} \n" +
            $"Size : {Size} \n" +
            $"color : {Color} \n" +
            $"Description : {Description} \n" +
            $"ImageUrl : {ImageUrl} \n" + 
            $"Stock : {Stock}";
    }
}

