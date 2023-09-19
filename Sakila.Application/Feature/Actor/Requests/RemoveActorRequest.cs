using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Sakila.Application.Feature.Actor.Requests
{
    public class RemoveActorRequest : IRequest<bool>
    {
        public int ActorId { get; set; }
    }
}
