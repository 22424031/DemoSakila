using Microsoft.AspNetCore.Mvc;
using Sakila.Application.Feature.Actor.Requests;
using Sakila.Application.Dtos.Actors;
using MediatR;
using Sakila.Application.Dtos.Common;
using DemoSakila.Controllers;

namespace DemoSakila.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Actor : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<Actor> _logger;

        public Actor(IMediator mediator, ILogger<Actor> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        /// <summary>
        /// Get All Actor List
        /// </summary>

        /// <returns>all actor</returns>
        ///<remarks>
        ///sample request:
        ///Get /
        ///</remarks>
        ///<response code="200">Get Data sucessfull</response>
        ///<response code="204">No record found in table</response>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IReadOnlyList<ActorDto>>> GetListAsync()
        {
            _logger.LogInformation("hello");
            var request = new GetActorListAsyncRequest();
            var datas = await _mediator.Send(request);
            return datas.ToList();
        }

      /// <summary>
      /// Get actor by id
      /// </summary>
      /// <param name="id">2</param>
      /// <returns>an actor found by id</returns>
     ///<remark>
     ///sample request:
     ///Get/
     ///</remark>
     ///<response code="200">found actor</response>
     ///<response code="204">not found actor</response>
     ///<response code="400">bad request</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActorDto> GetByIdAsync(int id)
        {
            var request = new GetActorByIdRequest { id = id};
            var data = await _mediator.Send(request);
            return data;
        }
        /// <summary>
        /// Create new actor
        /// </summary>
        /// <param name="first_name">Tru</param>
        /// <param name="last_name">Tran</param>
        /// <returns>an actor new</returns>
        /// <remarks>
        /// request sample:
        /// 
        /// Post /Actor
        /// {
        ///     { 
        ///     "first_name": "Tru",
        ///     "last_name": "Tran" 
        ///     }
        /// }
        /// </remarks>
        /// <response code="201">Returns the newly created actor</response>
        /// <response code="400">If the actor is null</response>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponse<ActorDto>>> AddAsync([FromBody] CreateActor actor)
        {
            var request = new CreateActorRequest {  ActorDto = actor };
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
