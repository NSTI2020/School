using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Repository.Data;

namespace School.WebApi.Controllers
{

    [ApiController]
    [Route("api/{controller}")]
    public class AddressesController : ControllerBase
    {
        private readonly ISchoolRepository _repo;

        public AddressesController(ISchoolRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            Address[] addresses = await _repo.GetAllAddressesAsync();

            return Ok(addresses);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Address model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/addresses/{model.Id}", model);
                }
            }
            catch (System.Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, $"A base de dados falhou. Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpGet("{seed}")]
        public string seed()
        {
            Address addr = new Address()
            {
                Street = "Rua Arcos",
                Number = "217",
                Neighborhood = "Vera Cruz",
                City = "Belo Horizonte",
                State = "Minas Gerais",
                Complement = "ddddddddddddddddd"
            };

            _repo.Add(addr);

            if (_repo.SaveChanges())
            {
                return "Deu BOM, foi salvo.....";
            }

            return "Não salvou....";

        }



    }

}