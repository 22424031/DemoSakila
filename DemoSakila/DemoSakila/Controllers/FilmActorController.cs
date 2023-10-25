using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using DemoSakila.API.Authentication;
using Sakila.Application.Dtos.Common;
using Sakila.Application.Dtos.Films;
using Sakila.Application.Feature.Film.Request;
using Sakila.Application.Dtos.FilmActor;
using Sakila.Application.Feature.FilmActor.Request;
using MySqlX.XDevAPI;
using System.Net;

namespace DemoSakila.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmActorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FilmActorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetListAsync")]
        public async Task<ActionResult<BaseResponse<object>>> GetListAsync()
        {
            var baseResponse = new BaseResponse<object>();
            var request = new GetListFilmActorRequest();
            var data = await _mediator.Send(request);
            if (data == null)
            {
                baseResponse.ErrorMessage = "not found";
                baseResponse.Status = 204;
                return baseResponse;
            }
            baseResponse.Status = 200;
            baseResponse.Data = data;
            return baseResponse;
        }

        
           
}
}
