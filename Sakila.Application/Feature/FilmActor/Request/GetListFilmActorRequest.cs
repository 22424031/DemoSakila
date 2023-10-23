using MediatR;
using Sakila.Application.Dtos.FilmActor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Feature.FilmActor.Request
{
    public class GetListFilmActorRequest : IRequest<object>
    {
    }
}
