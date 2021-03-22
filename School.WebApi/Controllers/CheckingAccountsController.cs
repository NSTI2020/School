using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Repository.Data;

namespace School.WebApi.Controllers
{

    [ApiController]
    [Route("api/{controller}")]
    public class CheckingAccountsController : ControllerBase
    {
        private readonly ISchoolRepository _repo;
        public CheckingAccountsController(ISchoolRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            CheckingAccount[] checkingAccount = await _repo.GetAllCheckingAccountAsync();
            return Ok(checkingAccount);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CheckingAccount model)
        {
            _repo.Add(model);

            if (await _repo.SaveChangesAsync())
            {
                return Created($"api/checkingaccount/{model.Id}", model);

            }
            return BadRequest();
        }



    }


}