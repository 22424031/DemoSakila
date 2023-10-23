using Microsoft.EntityFrameworkCore;
using Sakila.Application.Contracts.FilmActors;
using Sakila.Application.Dtos.FilmActor;
using Sakila.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Persistent.Repositories
{
    public class FilmActorRepository : GenericRepository<FilmActor>, IFilmActorRepository
    {
        private readonly SakilaContext _dbcontext;
        public FilmActorRepository(SakilaContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task SaveChange()
        {
            await _dbcontext.SaveChangeAsync("system");
        }
        public async Task<object> GetListAsync()
        {
            var datas = await ( from f in _dbcontext.film
                               join fa in _dbcontext.film_actor on f.Film_Id equals fa.Film_Id
                               join a in _dbcontext.actor on fa.Actor_Id equals a.Actor_Id
                               
                              // select new { f,a };
                        select new { a.Actor_Id, a.First_Name, a.Last_Name, f.Film_Id, f.Title, f.Description, f.Release_Year, f.Language_Id, f.Original_Language_Id, f.Rental_Duration, f.Rental_Rate, f.Length, f.Replacement_Cost, f.Rating} ).Take(100).ToListAsync();
            return datas;
        }
    }
}
