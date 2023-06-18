using ConectionMongoClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ConectionMongoClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ClientController(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbCLient = new MongoClient(_configuration.GetConnectionString("UserClient"));
            var dbList = dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").AsQueryable();
            return new JsonResult(dbList);  
        }
        [HttpPost]
        public JsonResult Post(Client client)
        {
            MongoClient dbCLient = new MongoClient(_configuration.GetConnectionString("UserClient"));
            var lastClient = dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").AsQueryable().Count();
            client.ClientId = lastClient + 1;
            dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").InsertOne(client);
            return new JsonResult("Addes Succesfully");
        }

        [HttpPut]
        public JsonResult Put(Client client)
        {
            MongoClient dbCLient = new MongoClient(_configuration.GetConnectionString("UserClient"));
            var filter = Builders<Client>.Filter.Eq("ClientId", client.ClientId);
            var update = Builders<Client>.Update.Set("Name", client.Name);
            dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").UpdateOne(filter,update);
            return new JsonResult("Update Succesfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbCLient = new MongoClient(_configuration.GetConnectionString("UserClient"));
            var filter = Builders<Client>.Filter.Eq("ClientId", id);
            
            dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").DeleteOne(filter);
            return new JsonResult("Delete Succesfully");
        }

    }
}
