using Amazon.Runtime.Internal;
using ConectionMongoClient.Models;
using DnsClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        [HttpPost("Login")]
        public ActionResult<Client> Login(ClientDto request)
        {
            Client user = new Client();
            user.Email = request.Email;
            user.Password = request.Password;
            MongoClient dbCLient = new MongoClient(_configuration.GetConnectionString("UserClient"));
            var filter = Builders<Client>.Filter.Eq("Email", request.Email);
            var lastclient = dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").Find(filter).ToList();


            if (lastclient.Count() == 0 || request.Email != lastclient[0].Email)
            {
                return BadRequest("User not found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, lastclient[0].Password))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(lastclient[0]);


            return new OkObjectResult(new { value = token, user = lastclient[0].id });
        }

        [HttpPost("Register")]
        public ActionResult<Client> Register(ClientDto request)
        {
            Client user = new Client();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Email = request.Email;
            user.Password = passwordHash;

            MongoClient dbCLient = new MongoClient(_configuration.GetConnectionString("UserClient"));
            var filter = Builders<Client>.Filter.Eq("Email", request.Email);
            var check = dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").Find(filter).ToList().Count();
            
            if (check > 0)
            {
                return BadRequest("This e-mail address is already registered.");
            }

            var lastClient = dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").AsQueryable().Count();
            user.ClientId = lastClient + 1;
            dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").InsertOne(user);
            return Ok("User created");

        }

        [HttpPut("Update"), Authorize]

        public  async Task<ActionResult<Client>> Update(Client request)
        {
            var protectedField = new List<string> {"id","Rol","ClientId","Password","Email"};
            MongoClient dbCLient = new MongoClient(_configuration.GetConnectionString("UserClient"));
            var filter = Builders<Client>.Filter.Eq("Email", request.Email);
            var updatedict = new List<UpdateDefinition<Client>>();
            foreach (var prop in request.GetType().GetProperties())
            {
                if (!protectedField.Any(prop.Name.Contains))
                {
                    updatedict.Add(Builders<Client>.Update.Set(prop.Name, prop.GetValue(request)));
                }

            }

            var update = Builders<Client>.Update.Combine(updatedict);
            await dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").UpdateOneAsync(filter, update);
            return Ok("");
        }

        [HttpGet("User"), Authorize]
        public ActionResult<Client> User(string request, string limit)
        {

            MongoClient dbCLient = new MongoClient(_configuration.GetConnectionString("UserClient"));
            var filter = Builders<Client>.Filter.Eq("_id", ObjectId.Parse(request));
            var lastclient = dbCLient.GetDatabase("Usuarios").GetCollection<Client>("Clients").Find(filter).ToList();
            if(limit == "permission")
            {
                return Ok(lastclient[0].Rol);
            }
            if (limit == "Simple")
            {
                return new OkObjectResult(new { name = lastclient[0].Name, email = lastclient[0].Email , rol = lastclient[0].Rol});
            }

            return Ok(lastclient);
        }

        private string CreateToken(Client client)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, client.id.ToString()),
                new Claim(ClaimTypes.Role,client.Rol),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Setting:Token").Value!
                )) ;
            var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims:claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:credencials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

    }
}
