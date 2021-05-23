using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RecipeProject.Entities.Interfaces;

namespace RecipeProject.Entities.Concrete
{
    public class AppUser : ITable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public AppRole AppRole { get; set; }

    }
}
