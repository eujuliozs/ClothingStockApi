namespace ClothingApi.Model;

public abstract class Clothes
{
    public string Name { get; set; }
    public int size { get; set; }
    public string color { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
