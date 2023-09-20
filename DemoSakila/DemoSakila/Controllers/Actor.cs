using Microsoft.AspNetCore.Mvc;
using Sakila.Application.Feature.Actor.Requests;
using Sakila.Application.Dtos.Actors;
using MediatR;

namespace DemoSakila.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Actor : ControllerBase
    {
        private readonly IMediator _mediator;
       public Actor(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<ActorDto>>> GetListAsync()
        {

            var request = new GetActorListAsyncRequest();
            var datas = await _mediator.Send(request);
            return datas.ToList();
        }
        [HttpGet("{id}")]
        public async Task<ActorDto> GetByIdAsync(int id)
        {

            var request = new GetActorByIdRequest { id = id};
            var data = await _mediator.Send(request);
            return data;
        }
        [HttpPost()]
        public async Task<ActorDto> AddAsync([FromBody] CreateActor actor)
        {

            var request = new AddActorRequest {  ActorDto = actor };
            var data = await _mediator.Send(request);
            return data;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromForm] ActorDto actor)
        {
            actor.Actor_id = id;
            var request = new UpdateActorRequest { ActorDto = actor };
            var isSuccess = await _mediator.Send(request);
            return StatusCode(isSuccess ? 200 : 500);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var request = new RemoveActorRequest {  ActorId = id };
            return await _mediator.Send(request);
           
        }
    }
}
