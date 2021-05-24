using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RecipeProject.Entities.Interfaces;
using System;

namespace RecipeProject.Entities.Concrete
{
    public class Recipe : ITable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
    }
}
