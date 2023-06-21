namespace ConectionMongoClient.Models
{
    public class PersonalClient
    {
        public string  Phone { get; set; }
        public string Address { get; set; }
        public string CivilStatus { get; set; }
        public string Birthday { get; set; }
        public Boolean Automovil { get; set; }
        public SpouseClient ? Spouse { get; set; }
    }
}
