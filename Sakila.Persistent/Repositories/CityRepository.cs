using Microsoft.EntityFrameworkCore;
using Sakila.Application.Contracts.Citys;
using Sakila.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Persistent.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        //private readonly SakilaContext _abcConect;
        public CityRepository(SakilaContext dbContext) : base(dbContext)
        {
           // this._abcConect = dbContext;
        }

        public async Task<City> SearchCity(string cityname)
        {
            return null;
           //return await _abcConect.city.FirstOrDefaultAsync(x => x.city  == cityname);
        }
    }
}
