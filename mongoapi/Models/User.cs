using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mongoapi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // bson ObjectId
        public string Id { get; set; }

        // props
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
