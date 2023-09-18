using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sakila.Domain;

namespace Sakila.Application.Feature.Actor.Requests
{
    public class GetActorListAsyncRequest : IRequest<IReadOnlyList<Dtos.Actors.ActorDto>>
    {

    }
}
