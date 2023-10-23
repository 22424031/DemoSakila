using AutoMapper;
using MediatR;
using Sakila.Application.Contracts.Films;
using Sakila.Application.Dtos.Films;
using Sakila.Application.Feature.Film.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Feature.Film.Handler
{
    public class GetListFilmHandler : IRequestHandler<GetListFilmRequest, List<FilmDto>>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;
        public GetListFilmHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }
        public async Task<List<FilmDto>> Handle(GetListFilmRequest request, CancellationToken cancellationToken)
        {
            var datas = await _filmRepository.GetAll();
            return _mapper.Map<List<FilmDto>>(datas);
        }
    }
}
