using ClothingApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace ClothingApi.Model;

public abstract class Clothes : Entity
{
    public string? Name { get; set; }

    public int? Stock { get; set; }

    public string? color { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    [SizeValidation]
    public string? Size { get; set; }

    public override string ToString()
    {
        return $"ID :{Id} \n" +
            $"Name : {Name} \n" +
            $"Size : {Size} \n" +
            $"color : {color} \n" +
            $"Description : {Description} \n" +
            $"ImageUrl : {ImageUrl} \n" + 
            $"Stock : {Stock}";
    }
}

