using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sakila.Application.Contracts.Actor;
using Sakila.Application.Feature.Actor.Requests;

namespace Sakila.Application.Feature.Actor.Handlers
{
    public class RemoveActorHandler : IRequestHandler<RemoveActorRequest, bool>
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMediator _mediator;
        public  RemoveActorHandler(IMediator mediator ,IActorRepository actorRepository)
        {
            _mediator = mediator;
            _actorRepository = actorRepository;
        }

        public async Task<bool> Handle(RemoveActorRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var actor = await _actorRepository.Get(request.ActorId);
                await _actorRepository.Delete(actor);
                await _actorRepository.SaveChange();
                return true;
            }
            catch (Exception) { }
            return false;
        }
    }
}
