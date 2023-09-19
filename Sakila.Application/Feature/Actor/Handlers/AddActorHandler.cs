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
    public class AddActorHandler : IRequestHandler<AddActorRequest, Dtos.Actors.ActorDto>
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;

        public AddActorHandler(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public async Task<Dtos.Actors.ActorDto> Handle(AddActorRequest request, CancellationToken cancellationToken)
        {
            var data = await _actorRepository.Add(_mapper.Map<Domain.Actor>(request.ActorDto));
            await _actorRepository.SaveChange();
            return _mapper.Map<Dtos.Actors.ActorDto>(data);
        }
    }
}
