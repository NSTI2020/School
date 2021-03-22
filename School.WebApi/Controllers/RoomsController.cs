using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Repository.Data;

namespace School.WebApi.Controllers
{

    [ApiController]
    [Route("api/{controller}")]
    public class RoomsController : ControllerBase
    {
        private readonly ISchoolRepository _repo;
        public RoomsController(ISchoolRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Room[] rooms = await _repo.GetAllRoomAsync();

            return Ok(rooms);

        }
        [HttpPost]
        public async Task<IActionResult> Put(Room model)
        {
            _repo.Add(model);
            if (await _repo.SaveChangesAsync())
            {
                return Created($"api/rooms/{model.Id}", model);
            }
            return BadRequest();
        }




    }



}