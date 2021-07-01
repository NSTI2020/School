using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using School.Domain.Entities;
using School.Repository.Data;
using Microsoft.AspNetCore.Http;

namespace School.WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class UnitsController : ControllerBase
    {
        private readonly ISRepository _repo;
        public UnitsController(ISRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Unit model)
        {
            try
            {
                if (model == null) return NotFound();
                //    Unit unit = model;
                //    unit.Address = model.Address;
                //    unit.Contact = model.Contact;



                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/units/{model.Id}", model);
                }
            }
            catch (System.Exception msg)
            {
                this.StatusCode(StatusCodes.Status500InternalServerError, $"A base de dados falhou. Erro: {msg.Message}");
            }
            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Unit[] unit = await _repo.GetAllUnitsAsync(true);

                if (unit == null) return NotFound();
                return Ok(unit);
            }
            catch (System.Exception msg)
            {
                this.StatusCode(StatusCodes.Status500InternalServerError, $"A base de dados falhou. Erro: {msg.Message}");
            }
            return BadRequest();
        }

    }
}