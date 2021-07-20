using Api.Data.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infected> _infectedCollection;

        public InfectedController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        [HttpPost]
        public ActionResult PostInfected([FromBody] InfectedDto dto)
        {
            var infected = new Infected(dto.BirthDate, dto.Sex, dto.Latitude, dto.Longitude);

            _infectedCollection.InsertOne(infected);
            
            return StatusCode(201, "Infected successfully added");
        }

        [HttpGet]
        public ActionResult GetInfecteds()
        {
            var infected = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();
            
            return Ok(infected);
        }
    }
}
