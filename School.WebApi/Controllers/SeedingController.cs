using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Repository.Data;

namespace School.WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class SeedingController : ControllerBase
    {
        public SeedingService _seeding { get; set; }

        public SeedingController(SeedingService seeding)
        {
            _seeding = seeding;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> get()
        {
            string[] msgs = new string[] { "DataBase was seeded!", "Seed DataBase fail" };

            if (await _seeding.Seed())
            {
                return Ok(msgs[0]);
            }
            else
            {

                return Ok(msgs[1]);
            }
        }
    }
}
