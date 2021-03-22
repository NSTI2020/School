using System.Collections.Generic;
using System.Threading.Tasks;
using School.Domain.Entities;

namespace School.Repository.Data
{
    public class SeedingService
    {
        private readonly SchoolDbContext _context;
      //  private Seeding _seeding { get; set; }
        public SeedingService(SchoolDbContext context)
        {
            _context = context;

        }

      /*  public async Task<bool> Seed()
        {
           // _seeding = new Seeding(_context);

         //   return await _seeding.Classes();
        }*/
    }
}
