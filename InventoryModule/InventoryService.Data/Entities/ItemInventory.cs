using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Data.Entities
{
    public class ItemInventory
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;


        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string InventoryId { get; set; } = null!;


        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string ItemId { get; set; } = null!;


        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int Count { get; set; }


    }
}
