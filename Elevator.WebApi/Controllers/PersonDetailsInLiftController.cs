using AutoMapper;
using ES.DataAccess;
using ES.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elevator.WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PersonDetailsInLiftController : Controller
    {
        private readonly DbContextAccess dbContextAccess;

        public PersonDetailsInLiftController(DbContextAccess dbContextAccess)
        {
            this.dbContextAccess = dbContextAccess;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonDetailsInLift() {
            return Ok(await dbContextAccess.PersonDetailsInLifts.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> InsertPersonDetails(AddPersonDetails addPersonDetails)
        {
            if(addPersonDetails != null) {
                PersonDetailsInLift personDetailsInLift = new PersonDetailsInLift();
                personDetailsInLift.Id = new Guid();
                //personDetailsInLift = Mapper.Map<PersonDetailsInLift>(addPersonDetails);
                personDetailsInLift.PersonId = addPersonDetails.PersonId;
                personDetailsInLift.Weight = addPersonDetails.Weight;
                personDetailsInLift.FromFloorNum = addPersonDetails.FromFloorNum;
                personDetailsInLift.ToFloorNum = addPersonDetails.ToFloorNum;
                personDetailsInLift.Status = addPersonDetails.Status;

                await dbContextAccess.PersonDetailsInLifts.AddAsync(personDetailsInLift);
                await dbContextAccess.SaveChangesAsync();
                return Ok(personDetailsInLift);
            }
            else { return BadRequest("Invalid details"); }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePersonDetails([FromRoute] Guid id,AddPersonDetails addPersonDetails)
        {
            if(addPersonDetails != null)
            {
                var personDetail = await dbContextAccess.PersonDetailsInLifts.FirstOrDefaultAsync(x => x.Id == id);

                if (personDetail != null)
                {
                    personDetail.PersonId = addPersonDetails.PersonId;
                    personDetail.Weight = addPersonDetails.Weight;
                    personDetail.FromFloorNum = addPersonDetails.FromFloorNum;
                    personDetail.ToFloorNum = addPersonDetails.ToFloorNum;
                    personDetail.Status = addPersonDetails.Status;

                    dbContextAccess.PersonDetailsInLifts.Update(personDetail);
                    await dbContextAccess.SaveChangesAsync();
                }

                return Ok(personDetail);
            }
            else
            {
                return BadRequest("Not available");
            }
        }


        [HttpPut]
        [Route("{id:guid}/{status}")]
        public async Task<IActionResult> UpdateStatus([FromRoute] Guid id, [FromRoute] string status)
        {
                var personDetail = await dbContextAccess.PersonDetailsInLifts.FirstOrDefaultAsync(x => x.Id == id);

                if (personDetail != null)
                {
                    personDetail.Status = status;

                    dbContextAccess.PersonDetailsInLifts.Update(personDetail);
                    await dbContextAccess.SaveChangesAsync();
                }

                return Ok(personDetail);
        }

        //public async Task<IActionResult> UpdateStatus([FromRoute] Guid id,string status)
        //{
        //    var personDetail = await dbContextAccess.PersonDetailsInLifts.FirstOrDefaultAsync(x => x.Id == id);
        //    if(personDetail != null)
        //    {
        //        personDetail.Status = status;
        //        dbContextAccess.PersonDetailsInLifts.Update(personDetail);
        //        await dbContextAccess.SaveChangesAsync();
        //    }
        //    return Ok(personDetail);
        //}

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePersondetails([FromRoute] Guid id)
        {
            var personDetail = dbContextAccess.PersonDetailsInLifts.FirstOrDefault(x => x.Id == id);
            if(personDetail != null)
            {
                dbContextAccess.PersonDetailsInLifts.Remove(personDetail);
                await dbContextAccess.SaveChangesAsync();
            }
            return Ok(personDetail);
        }
    }
}
