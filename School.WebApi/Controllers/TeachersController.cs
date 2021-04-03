using System;
using System.Collections.Generic;
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
                this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"A base de dados falhou. Erro {e.Message}");
            }
            return BadRequest();

        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            Teacher teacher = await _repo.GetTeacherByIdAsync(Id);
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Teacher model)
        {

            _repo.Add(model);

              /*          model.DisciplineTeacher.ForEach(item =>{
            var _dt = new DisciplineTeacher();
                _dt = item;
                _dt.TeacherId = model.Id;
                _repo.Add(_dt);

            });*/
            
            if (await _repo.SaveChangesAsync())
            {
                return Created($"api/teachers/{model.Id}", model);
            }
            return BadRequest();
        }

    }
}
