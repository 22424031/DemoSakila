using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Feature.Actor.Requests
{
    public class AddActorRequest : IRequest<Dtos.Actors.ActorDto>
    {
        public Dtos.Actors.CreateActor ActorDto { get; set; }
    }
}
