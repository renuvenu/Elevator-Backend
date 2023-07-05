using ES.DataAccess;
using ES.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elevator.WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class FloorController: Controller
    {
        private readonly DbContextAccess dbContextAccess;
        static int FloorNumber = 1;

        public FloorController(DbContextAccess dbContextAccess)
        {
            this.dbContextAccess = dbContextAccess;
        }

        [HttpPost]
        [Route("{count}")]
        public async Task<IActionResult> AddFloors([FromRoute] int count)
        {
            if(count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Floor floor = new Floor();
                    floor.Id = new Guid();
                    floor.FloorNum = FloorNumber;
                    await dbContextAccess.Floors.AddAsync(floor);
                    await dbContextAccess.SaveChangesAsync();
                    FloorNumber++;
                }
                return Ok(true);
            }
            return BadRequest("Enter valid number of floors!!!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFloors()
        {
            return Ok(await dbContextAccess.Floors.ToListAsync());
        }
    }
}
