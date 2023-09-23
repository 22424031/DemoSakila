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
        private readonly SakilaContext _sakilaContext;
        public CityRepository(SakilaContext dbContext) : base(dbContext)
        {
           _sakilaContext = dbContext;
        }

        public async Task<City> SearchCity(string cityname)
        {
            City rs = await _sakilaContext.city.FirstOrDefaultAsync(x => x.city == cityname);
            return rs;
        }
    }
}
