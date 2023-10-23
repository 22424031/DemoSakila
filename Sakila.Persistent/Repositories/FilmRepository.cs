using Microsoft.EntityFrameworkCore;
using Sakila.Application.Contracts.Films;
using Sakila.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Persistent.Repositories
{
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        private readonly SakilaContext   _context;
        public FilmRepository(SakilaContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public async Task SaveChange()
        {
            await _context.SaveChangeAsync("system");
        }
    }
}
