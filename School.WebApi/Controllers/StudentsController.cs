using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Repository.Data;
using System.Linq;


namespace School.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {

        private readonly ISchoolRepository _repo;
        public StudentsController(ISchoolRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            try
            {
                Student[] students = await _repo.GetAllStudentAsync();
                return Ok(students);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"A Base de dados falhou. Erro: {ex.Message}");
            }

        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudentsByIdAsync(int Id)
        {
            Student student = await _repo.GetStudentByIdAsync(Id);
            return Ok(student);
        }


        [HttpGet("Put/{Id}")]
        public async Task<IActionResult> Put(int Id)
        {

            Student student = await _repo.GetStudentByIdAsync(Id);

            //if (student == null) return NotFound();

            return Ok(student);

        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(Student model)
        {

            _repo.Update(model);

            if (await _repo.SaveChangesAsync())
            {
                return Created($"api/students/{model.Id}", model);
            }

            return BadRequest();

        }






    }


}
