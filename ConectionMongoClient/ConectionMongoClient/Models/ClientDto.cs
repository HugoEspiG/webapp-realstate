namespace ConectionMongoClient.Models
{
    public class ClientDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }  
        public string? Name { get; set; }
        public string? Rol { get; set; } 
    }
}
