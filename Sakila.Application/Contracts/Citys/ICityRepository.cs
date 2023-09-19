using Sakila.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Contracts.Citys
{
    public interface ICityRepository: IGenericRepository<City>
    {
        Task<City> SearchCity(string cityname);
    }
}
