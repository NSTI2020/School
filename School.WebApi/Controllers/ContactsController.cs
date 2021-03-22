using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Repository.Data;

namespace School.WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ContactsController : ControllerBase
    {
        private readonly ISchoolRepository _repo;
        public ContactsController(ISchoolRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Contact model)
        {
            _repo.Add(model);

            if (await _repo.SaveChangesAsync())
            {
                return Created($"api/contacts/{model.Id}", model);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Contact[] contacts = await _repo.GetAllContactAsync();

            if (contacts == null)
            {
                return Ok(null);
            }
            
            return Ok(contacts);

        }




    }





}