using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sakila.Application.Contracts.Citys;
using Sakila.Application.Dtos.Citys;
using Sakila.Application.Feature.City.Request;
using AutoMapper;

namespace Sakila.Application.Feature.City.Handler
{
    public class GetCityListHandler : IRequestHandler<GetCityListRequest, IReadOnlyList<Dtos.Citys.CityDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public GetCityListHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CityDto>> Handle(GetCityListRequest request, CancellationToken cancellationToken)
        {
            var datas = await _cityRepository.GetAll();
            return _mapper.Map<IReadOnlyList<CityDto>> (datas);
        }
    }
}
