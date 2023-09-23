using MediatR;
namespace Sakila.Application.Feature.Actor.Requests
{
    public class UpdateActorRequest : IRequest<bool>
    {
        public Dtos.Actors.ActorDto ActorDto { get; set; }
    }
}
