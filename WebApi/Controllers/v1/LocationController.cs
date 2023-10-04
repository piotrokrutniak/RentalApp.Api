using Application.Features.Images.Queries;
using Application.Features.Locations.Commands.Create;
using Application.Features.Locations.Commands.Delete;
using Application.Features.Locations.Commands.Update;
using Application.Features.Locations.Queries.All;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{

    [ApiVersion("1.0")]
    public class LocationController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetLocationsParameter filter)
        {
          
            return Ok(await Mediator.Send(new GetLocationsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber  }));
        }

        
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetLocationByIdQuery { Id = id }));
        }
        
        // POST api/<controller>
        [HttpPost]
        //[Authorize(Roles= "Moderator,SuperAdmin,Admin")]
        //[Authorize]
        public async Task<IActionResult> Post([FromForm] CreateLocationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateLocationCommand command)
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
            return Ok(await Mediator.Send(new DeleteLocationByIdCommand { Id = id }));
        }
    }
}
