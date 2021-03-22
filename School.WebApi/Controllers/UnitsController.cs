using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Repository.Data;

namespace School.WebApi.Controllers
{

    [ApiController]
    [Route("api/{controller}")]
    public class UnitsController : ControllerBase
    {
        private readonly ISchoolRepository _repo;
        public UnitsController(ISchoolRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Unit model)
        {
            _repo.Add(model);
            if (await _repo.SaveChangesAsync())
            {
                return Created($"api/controller/{model.Id}", model);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Unit[] units = await _repo.GetAllUnitAsync();

            return Ok(units);

        }
        
        [HttpGet("{seed}")]
        public async Task<string> seed()
        {
            Address address = new Address()
            {
                Street = "Rua Espirito Santo",
                Number = "1137",
                Neighborhood = "Lourdes",
                City = "Belo Horizonte",
                State = "Minas Gerais",
                Complement = "Luiziana Lanna"
            };

            Unit unit = new Unit()
            {
                Name = "Nova Cintra",
                // Rooms = "",
                //CheckingAccounts = "",
                //Students = "",
                //Teachers = "",
                AddressId = 6,
                //Address = address
            };

            _repo.Add(unit);
            if (await _repo.SaveChangesAsync())
            {
               return "Deu BOM, foi salvo.....";
            }
            
            return "Não Salvou";


        }


    }
}