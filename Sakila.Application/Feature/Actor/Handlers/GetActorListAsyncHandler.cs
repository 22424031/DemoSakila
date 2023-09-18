using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sakila.Application.Contracts.Actor;
using Sakila.Application.Feature.Actor.Requests;

namespace Sakila.Application.Feature.Actor.Handlers
{
    public class GetActorListAsyncHandler : IRequestHandler<GetActorListAsyncRequest, IReadOnlyList<Dtos.Actors.ActorDto>>
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;

        public GetActorListAsyncHandler(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<Dtos.Actors.ActorDto>> Handle(GetActorListAsyncRequest request, CancellationToken cancellationToken)
        {
            var actors = await _actorRepository.GetAll();
            return _mapper.Map<IReadOnlyList<Dtos.Actors.ActorDto>> (actors);
        }
    }
}
