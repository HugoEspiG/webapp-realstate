using MongoDB.Bson.IO;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace ConectionMongoClient.Models
{
    public class FamilyClient
    {
        private dynamic dependientes;
        public int FamilyCount { get; set; } 
        public dynamic? Dependientes { 
            get { return dependientes; } 
            set { dependientes = JsonSerializer.Serialize(value); } 
        }
    }

}
