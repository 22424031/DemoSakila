using Sakila.Application.Dtos.FilmActor;
using Sakila.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Contracts.FilmActors
{
    public interface IFilmActorRepository : IGenericRepository<FilmActor>
    {
        Task<object> GetListAsync();
    }
}
