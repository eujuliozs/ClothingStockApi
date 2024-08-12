using Dapper.Contrib.Extensions;

namespace ClothingApi.Model
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
