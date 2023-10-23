using Sakila.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Contracts.Films
{
    public interface IFilmRepository : IGenericRepository<Film>
    {
    }
}
