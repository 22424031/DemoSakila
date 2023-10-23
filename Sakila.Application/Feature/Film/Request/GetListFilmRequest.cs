using MediatR;
using Sakila.Application.Dtos.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Feature.Film.Request
{
    public class GetListFilmRequest:IRequest<List<FilmDto>>
    {
    }
}
