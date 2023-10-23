using AutoMapper;
using MediatR;
using Sakila.Application.Contracts.FilmActors;
using Sakila.Application.Dtos.FilmActor;
using Sakila.Application.Feature.FilmActor.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Feature.FilmActor.Handler
{
    public class GetListFilmActorHandler : IRequestHandler<GetListFilmActorRequest, object>
    {
        private readonly IMapper _mapper;
        private readonly IFilmActorRepository _filmActorRepository;
        public GetListFilmActorHandler(IMapper mapper, IFilmActorRepository filmActorRepository)
        {
            _mapper = mapper;
            _filmActorRepository = filmActorRepository;
        }

        public async Task<object> Handle(GetListFilmActorRequest request, CancellationToken cancellationToken)
        {
            var datas = await _filmActorRepository.GetListAsync();
            //  var films = datas;
            //return _mapper.Map<List<FilmActorDto>>(datas);
            return datas;
        }
    }
}
