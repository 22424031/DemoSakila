using Microsoft.AspNetCore.Http;
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

        [HttpGet("GetListAsync")]
        public async Task<ActionResult<IReadOnlyList<ActorDto>>> GetListAsync()
        {

            var request = new GetActorListAsyncRequest();
            var datas = await _mediator.Send(request);
            return datas.ToList();
        }
        [HttpGet("GetByIdAsync")]
        public async Task<ActorDto> GetByIdAsync(int id)
        {

            var request = new GetActorByIdRequest { id = id};
            var data = await _mediator.Send(request);
            return data;
        }
    }
}
