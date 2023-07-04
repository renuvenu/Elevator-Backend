using ES.DataAccess;
using ES.Model;
using ES.Model.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Elevator.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class PersonController: Controller
    {
        public static long userId = 1;
        private readonly DbContextAccess dbContextAccess;
        public PersonController(DbContextAccess dbContextAccess)
        {
            this.dbContextAccess = dbContextAccess;
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(PersonRequest personRequest)
        {
            if (personRequest != null)
            {
                Person person = new Person();
                person.UserId = "ID" + userId.ToString("0000");
                person.Name = personRequest.Name;
                person.OfficeName = personRequest.OfficeName;
                person.ContactNumber = personRequest.ContactNumber;
                userId++;
                await dbContextAccess.Persons.AddAsync(person);
                await dbContextAccess.SaveChangesAsync();
                return Ok(person);
            }
            return BadRequest("Please provide valid details.");
        }

        [HttpGet]
        [Route("/login")]
        public async Task<IActionResult> LoginPerson([FromHeader] String userId)
        {
            var person = dbContextAccess.Persons.FirstOrDefault(x => x.UserId == userId);
            if(person != null)
            {
                return Ok(person);
            }
            return BadRequest("Invalid user");
        }

        [HttpGet]
        [Route("/history")]
        public async Task<IActionResult> HistoryOfPerson([FromHeader] String userId)
        {
            bool  person = dbContextAccess.Persons.Any(x => x.UserId == userId);
            if (person)
            {
                var list = dbContextAccess.PersonDetailsInLifts.Where(x => x.PersonId == userId);
                if (list.Count() > 0)
                {
                    return Ok(await list.ToListAsync());
                }
                return Ok("No History record found");
            }
            else
            {
                return BadRequest("Invalid User");
            }
            
        }

    }
}
