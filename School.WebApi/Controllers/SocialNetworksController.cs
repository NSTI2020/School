using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Repository.Data;

namespace School.WebApi.Controllers
{

    [ApiController]
    [Route("api/{controller}")]
    public class SocialNetworksController : ControllerBase
    {
        private readonly ISchoolRepository _repo;
        public SocialNetworksController(ISchoolRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            SocialNetwork[] model = await _repo.GetAllSocialNetworkAsync();

            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> Post(SocialNetwork model)
        {
            _repo.Add(model);
            if (await _repo.SaveChangesAsync())
            {
                return Created($"api/SocialNetworks/{model.Id}", model);
            }
            return BadRequest();

        }




    }






}