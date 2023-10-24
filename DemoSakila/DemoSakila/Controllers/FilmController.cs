using DemoSakila.API.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sakila.Application.Dtos.Common;
using Sakila.Application.Dtos.Films;
using Sakila.Application.Feature.Film.Request;

namespace DemoSakila.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public FilmController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("list-validate-by-secret-key")]
        [ApiKeyAuthFilter]
        public async Task<ActionResult<BaseResponse<IReadOnlyList<FilmDto>>>> GetList1()
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("list-validate-by-token")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<IReadOnlyList<FilmDto>>>> GetList2()
        {
            return await GetList1();
        }
    }
}
