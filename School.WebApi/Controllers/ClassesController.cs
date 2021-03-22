using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Repository.Data;

namespace School.WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ClassesController : ControllerBase
    {
        private readonly ISchoolRepository _repo;
        public ClassesController(ISchoolRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClassesAsync()
        {
            try
            {
                Class[] classes = await _repo.GetAllClassesAsync();
                return Ok(classes);
            }
            catch (System.Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, $"A base de dados falho. Erro: {ex.Message}");
            }

            return BadRequest();
        }


        public async Task<IActionResult> Post(Class model)
        {
            
            _repo.Add(model);
            if (await _repo.SaveChangesAsync())
            {
                return Created($"api/classes/{model.Id}", model);
            }
            return BadRequest();

        }





    }
}
