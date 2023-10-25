using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sakila.Application.Dtos.Citys;
using MediatR;
using Sakila.Application.Feature.City.Request;

namespace DemoSakila.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public  CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetListAsync")]
        public async Task<ActionResult<IReadOnlyList<CityDto>>> GetListAsync(){
            var request =  new GetCityListRequest();
            var data = await _mediator.Send(request);
            if(data == null)
            {
                return StatusCode(204);
            }
            return data.ToList();
        }
    }
}
