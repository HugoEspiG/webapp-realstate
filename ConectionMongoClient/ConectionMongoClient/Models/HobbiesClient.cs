using Microsoft.VisualBasic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ConectionMongoClient.Models
{
    public class HobbiesClient
    {
        private dynamic sport;
        private dynamic literature;
        private dynamic foods;
        public dynamic Sport
        {
            get { return sport; }
            set { sport = JsonSerializer.Serialize(value); }
        }
        public dynamic Literature
        {
            get { return literature; }
            set { literature = JsonSerializer.Serialize(value); }
        }  
        public dynamic Foods
        {
            get { return foods; }
            set { foods = JsonSerializer.Serialize(value); }
        }       
    }
}
