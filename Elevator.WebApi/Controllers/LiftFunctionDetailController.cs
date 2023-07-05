using ES.DataAccess;
using ES.Model.Request;
using ES.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elevator.WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LiftFunctionDetailController : Controller
    {
        private readonly DbContextAccess dbContextAccess;

        public LiftFunctionDetailController(DbContextAccess dbContextAccess)
        {
            this.dbContextAccess = dbContextAccess;
        }

        [HttpGet]
        public async Task<IActionResult> GetLiftFunctionDetails()
        {
            return Ok(await dbContextAccess.LiftFunctionDetail.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> InsertFunctionDetails(FunctionDetailsRequest addFunctionDetails)
        {
            if (addFunctionDetails != null)
            {
                LiftFunctionDetails liftFunctionDetails = new LiftFunctionDetails();
                liftFunctionDetails.Id = new Guid();
                liftFunctionDetails.CurrentPostion = addFunctionDetails.CurrentPosition;
                liftFunctionDetails.EmergencyAlarm = addFunctionDetails.EmergencyAlarm;
                liftFunctionDetails.Fan = addFunctionDetails.Fan;
                liftFunctionDetails.FireAlarm = addFunctionDetails.FireAlarm;
                liftFunctionDetails.PowerStatus = addFunctionDetails.PowerStatus;


                await dbContextAccess.LiftFunctionDetail.AddAsync(liftFunctionDetails);
                await dbContextAccess.SaveChangesAsync();
                return Ok(liftFunctionDetails);
            }
            else { return BadRequest("Invalid details"); }
        }


        [HttpPut]
        [Route("CurrentPosition/{currentPosition}")]
        public async Task<IActionResult> UpdateEmergencyAlarm([FromRoute] int currentPosition)
        {
            var functionDetail = await dbContextAccess.LiftFunctionDetail.FirstOrDefaultAsync();

            if (functionDetail != null)
            {
                functionDetail.CurrentPostion = currentPosition;

                dbContextAccess.LiftFunctionDetail.Update(functionDetail);
                await dbContextAccess.SaveChangesAsync();
            }

            return Ok(functionDetail);
        }

        [HttpPut]
        [Route("EmergencyAlarm/{emergencyAlarm}")]
        public async Task<IActionResult> UpdateEmergencyAlarm([FromRoute] bool emergencyAlarm)
        {
            var functionDetail = await dbContextAccess.LiftFunctionDetail.FirstOrDefaultAsync();

            if (functionDetail != null)
            {
                functionDetail.EmergencyAlarm = emergencyAlarm;

                dbContextAccess.LiftFunctionDetail.Update(functionDetail);
                await dbContextAccess.SaveChangesAsync();
            }

            return Ok(functionDetail);
        }

        [HttpPut]
        [Route("FanStatus/{fan}")]
        public async Task<IActionResult> UpdateFan([FromRoute] bool fan)
        {
            var functionDetail = await dbContextAccess.LiftFunctionDetail.FirstOrDefaultAsync();

            if (functionDetail != null)
            {
                functionDetail.Fan = fan;

                dbContextAccess.LiftFunctionDetail.Update(functionDetail);
                await dbContextAccess.SaveChangesAsync();
            }

            return Ok(functionDetail);
        }

        [HttpPut]
        [Route("FireAlarmStatus/{fireAlarm}")]
        public async Task<IActionResult> UpdateFireAlarm([FromRoute] bool fireAlarm)
        {
            var functionDetail = await dbContextAccess.LiftFunctionDetail.FirstOrDefaultAsync();

            if (functionDetail != null)
            {
                functionDetail.FireAlarm = fireAlarm;

                dbContextAccess.LiftFunctionDetail.Update(functionDetail);
                await dbContextAccess.SaveChangesAsync();
            }

            return Ok(functionDetail);
        }
        [HttpPut]
        [Route("PowerStatus/{powerStatus}")]
        public async Task<IActionResult> UpdatePowerStatus([FromRoute] bool powerStatus)
        {
            var functionDetail = await dbContextAccess.LiftFunctionDetail.FirstOrDefaultAsync();

            if (functionDetail != null)
            {
                functionDetail.PowerStatus= powerStatus;

                dbContextAccess.LiftFunctionDetail.Update(functionDetail);
                await dbContextAccess.SaveChangesAsync();
            }

            return Ok(functionDetail);
        }
        //[HttpGet]
        //[Route("CurrentPosition")]
        //public async Task<IActionResult> GetCurrentPosition()
        //{
        //    var functionDetail = await dbContextAccess.LiftFunctionDetail.FirstOrDefaultAsync();

        //    if (functionDetail != null)
        //    {
        //        return Ok(functionDetail.CurrentPostion);
        //    }

        //    return NotFound();
        //}
        //[HttpGet]
        //[Route("EmergencyAlarm")]
        //public async Task<IActionResult> GetEmergencyAlarm()
        //{
        //    var functionDetail = await dbContextAccess.LiftFunctionDetail.FirstOrDefaultAsync();

        //    if (functionDetail != null)
        //    {
        //        return Ok(functionDetail.EmergencyAlarm);
        //    }

        //    return NotFound();
        //}
    }
}
