﻿using Amazon.Runtime.Internal;
using ConectionMongoClient.Models;
using DnsClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
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

        [HttpPost("login")]
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


            return Ok(token);
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

        [HttpPut("Update")]

        public  ActionResult<Client> Update(Client request)
        { 

            return Ok(request);
        }

        private string CreateToken(Client client)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, client.Name),
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
