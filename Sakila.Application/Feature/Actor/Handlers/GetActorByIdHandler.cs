using AutoMapper;
using MediatR;
using Sakila.Application.Contracts.Actor;
using Sakila.Application.Dtos.Actors;
using Sakila.Application.Feature.Actor.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Feature.Actor.Handlers
{
    public class GetActorByIdHandler : IRequestHandler<GetActorByIdRequest, Dtos.Actors.ActorDto>
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public GetActorByIdHandler(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }
        public async Task<ActorDto> Handle(GetActorByIdRequest request, CancellationToken cancellationToken)
        {
            var actor = await _actorRepository.Get(request.id);
            return _mapper.Map<ActorDto>(actor);
        }
    }
}
