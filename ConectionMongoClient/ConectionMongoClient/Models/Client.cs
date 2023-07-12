using MongoDB.Bson;

namespace ConectionMongoClient.Models
{
    public class Client
    {

        public ObjectId id { get; set; }
        public int ClientId { get; set; }
        public string ? Name { get; set; } =  String.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email{ get; set; } = string.Empty;

        public string ? Rol { get; set; } 
        public PersonalClient ? Personal { get; set; }

        public FamilyClient ? Family { get; set; }    
        public LaborClient ? Labor { get; set; }  
        public HobbiesClient ? Hobbies { get; set; }    


    }
}
