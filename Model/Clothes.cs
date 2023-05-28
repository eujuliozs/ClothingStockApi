namespace ClothingApi.Model;

public abstract class Clothes 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int size { get; set; }
    public string? color { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public override string ToString()
    {
        return $"ID :{Id} \n" +
            $"Name : {Name} \n" +
            $"Size : {size} \n" +
            $"color : {color} \n" +
            $"Description : {Description} \n" +
            $"ImageUrl : {ImageUrl} \n";
    }
}

