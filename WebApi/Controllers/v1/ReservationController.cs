using Application.Features.Reservations.Commands.Create;
using Application.Features.Reservations.Commands.Delete;
using Application.Features.Reservations.Commands.Other.All;
using Application.Features.Reservations.Commands.Other.ById;
using Application.Features.Reservations.Commands.Update;
using Application.Features.Reservations.Queries.All;
using Application.Features.Reservations.Queries.ById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{

    [ApiVersion("1.0")]
    public class ReservationController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get(GetReservationParameter filter)
        {

            return Ok(await Mediator.Send(new GetReservationQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetReservationByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize(Roles= "Moderator,SuperAdmin,Admin")]
        //[Authorize]
        public async Task<IActionResult> Post(CreateReservationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/<controller>
        [HttpPost("/CheckAvailabilityByModel/")]
        //[Authorize(Roles= "Moderator,SuperAdmin,Admin")]
        //[Authorize]
        public async Task<IActionResult> Post(CheckAvailabilityByModelCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/<controller>
        [HttpPost("/CheckAvailabilityByid/")]
        //[Authorize(Roles= "Moderator,SuperAdmin,Admin")]
        //[Authorize]
        public async Task<IActionResult> Post(CheckAvailabilityByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateReservationByIdCommand command)
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
            return Ok(await Mediator.Send(new DeleteReservationByIdCommand { Id = id }));
        }
    }
}
