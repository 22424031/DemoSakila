
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sakila.Application.Dtos.Citys;
using Sakila.Application.Dtos.Common;
using Sakila.Application.Dtos.Films;
using Sakila.Application.Feature.City.Request;
using Sakila.Application.Feature.Film.Request;

namespace DemoSakila.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FilmController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetListAsync")]

        public async Task<ActionResult<BaseResponse<IReadOnlyList<FilmDto>>>> GetListAsync()
        {
            var baseResponse = new BaseResponse<IReadOnlyList<FilmDto>>();
            var request = new GetListFilmRequest();
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
