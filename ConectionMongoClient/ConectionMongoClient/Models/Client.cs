using MongoDB.Bson;
using System.Text;

namespace ConectionMongoClient.Models
{
    public class Client
    {

        private string passwd;
        static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }


        public ObjectId id { get; set; }
        public int ClientId { get; set; }
        public string ? Name { get; set; }
        public string Password { get { return passwd; } set { passwd = sha256(value); } }
        public string Email{ get; set; }
        public PersonalClient ? Personal { get; set; }

        public FamilyClient ? Family { get; set; }    
        public LaborClient ? Labor { get; set; }  
        public HobbiesClient ? Hobbies { get; set; }    


    }
}
