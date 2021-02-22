using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Repository.Data;

namespace School.WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class TeachersController : ControllerBase
    {
        private readonly ISchoolRepository _repo;
        public TeachersController(ISchoolRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                Teacher[] teachers = await _repo.GetAllTeachersAsync();
                return Ok(teachers);
            }
            catch (System.Exception e)
            {
                StatusCode(StatusCodes.Status500InternalServerError, $"A base de dados falhou. Erro {e.Message}");
            }
            return BadRequest();

        }


    }
}
