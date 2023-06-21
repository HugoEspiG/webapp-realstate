using ConectionMongoClient.Models;
using DnsClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

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
        [Route("login")]
        public JsonResult Login(string login, string password)
        {
            Client client = new Client();
            client.Email = login;
            client.Password = password;
            MongoClient dbCLient = new MongoClient(_configuration.GetConnectionString("UserClient"));
            var filter = Builders<Client>.Filter.Eq("Email", client.Email);
            filter &= Builders<Client>.Filter.Eq("Password", client.Password);
            var lastclient = dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").Find(filter).ToList();


            return new JsonResult(lastclient);
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
        [HttpPost]
        [Route("Register")]
        public JsonResult Register(Client client)
        {
            MongoClient dbCLient = new MongoClient(_configuration.GetConnectionString("UserClient"));
            var filter = Builders<Client>.Filter.Eq("Email", client.Email);
            var check = dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").Find(filter).ToList().Count();
            
            if (check > 0)
            {
                return new JsonResult("This e-mail address is already registered.");
            }

            var lastClient = dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").AsQueryable().Count();
            client.ClientId = lastClient + 1;
            dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").InsertOne(client);
            return new JsonResult("Successfully added");

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
