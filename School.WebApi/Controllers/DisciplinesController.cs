
using System.Linq;
using System.Threading.Tasks;
using School.Domain.Entities;
using School.Repository.Data;
using Microsoft.AspNetCore.Mvc;

namespace School.WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class DisciplinesController : ControllerBase
    {
        private readonly ISchoolRepository _repo;

        public DisciplinesController(ISchoolRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            DisciplineTeacher[] models = await _repo.GetAllDisciplineAsync();

            return Ok(models);

        }


        [HttpPost]
        public async Task<IActionResult> Post(DisciplineTeacher model)
        {
            _repo.Add(model);
            if (await _repo.SaveChangesAsync())
            {
                return Created($"api/discipline/{model.Id}", model);
            }

            return BadRequest();
        }

        [HttpGet("{seed}")]
        public async Task<string> seed()
        {
            string[] language = new string[]
            {
                "Alemão", "Árabe", "Espanhol", "Italiano",
                 "Japonês", "Mandarim", "Francês", "Inglês", "Português"
            };

            foreach (string lang in language)
            {
                DisciplineTeacher dis = new DisciplineTeacher()
                {
                    Language = lang
                };
                _repo.Add(dis);
            }

            if (await _repo.SaveChangesAsync())
            {
                return "FOI CRIADO...";
            }
            return "Não foi criado... sniff";

        }

    }
}
