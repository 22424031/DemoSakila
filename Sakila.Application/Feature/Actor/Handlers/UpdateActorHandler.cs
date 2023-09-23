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
    public class UpdateActorHandler : IRequestHandler<UpdateActorRequest, bool>
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;

        public UpdateActorHandler(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateActorRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _actorRepository.Update(_mapper.Map<Domain.Actor>(request.ActorDto));
                await _actorRepository.SaveChange();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
