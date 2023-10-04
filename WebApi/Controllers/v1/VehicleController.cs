using Application.Features.Vehicles.Commands;
using Application.Features.Vehicles.Queries.All;
using Application.Features.Vehicles.Queries.ById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{

    [ApiVersion("1.0")]
    public class VehicleController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetVehicleParameter filter)
        {

            return Ok(await Mediator.Send(new GetVehicleQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetVehicleByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize(Roles= "Moderator,SuperAdmin,Admin")]
        //[Authorize]
        public async Task<IActionResult> Post([FromForm] CreateVehicleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateVehicleByIdCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));

        }

        //DELETE api/<controller>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteVehicleByIdCommand { Id = id }));
        }
    }
}
