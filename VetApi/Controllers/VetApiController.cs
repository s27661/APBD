using Microsoft.AspNetCore.Mvc;

namespace VetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VetApiController : ControllerBase
    {
        private readonly ILogger<VetApiController> _logger;
        public VetApiController(ILogger<VetApiController> logger) 
        {
            _logger = logger;
        }

        [HttpGet("animals")]
        public IActionResult GetAnimals([FromQuery] string? name) 
        {
            if (name != null)
            {
                return Ok(Database.GetAnimals().Where(x => x.Name == name));
            }
            return Ok(Database.GetAnimals());
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetAnimalById([FromRoute] int id)
        {
            var result = Database.GetAnimals().FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                return NotFound("Nie ma zwierzaka o takim id");
            }
            else
            {
                return Ok(result);
            }

        }
        public class AnimalHelper
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public double Weight { get; set; }
            public string Color { get; set; }

        }
        [HttpPost]
        public IActionResult AddAnimal([FromBody] AnimalHelper ah)
        {
            var animal = new Animal
            {
                Id = Database.GetAnimals().Max(x => x.Id) + 1,
                Name = ah.Name,
                Category = ah.Category,
                Weight = ah.Weight,
                Color = ah.Color
            };
            Database.AddAnimal(animal);
            return Created($"animals/{animal.Id}", animal);

        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult RemoveAnimal([FromRoute] int id)
        {
            var animal = Database.GetAnimals().FirstOrDefault(x => x.Id == id);
            if (animal == null)
            {
                return NotFound("nie ma takiego zwierzaka w systemie");
            }
            Database.RemoveAnimal(animal);
            return NoContent();
        }

        [HttpGet("visits")]
        public IEnumerable<Visit> GetVisits()
        {
            return Database.GetVisits().ToArray();
        }

    }
}
