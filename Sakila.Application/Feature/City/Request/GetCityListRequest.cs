using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Sakila.Application.Feature.City.Request
{
    public class GetCityListRequest : IRequest<IReadOnlyList<Dtos.Citys.CityDto>>
    {

    }
}
