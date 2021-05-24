using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RecipeProject.Entities.Interfaces;

namespace RecipeProject.Entities.Concrete
{
    public class Category : ITable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
