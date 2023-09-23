using Sakila.Domain;
namespace Sakila.Application.Contracts.Citys
{
    public interface ICityRepository: IGenericRepository<City>
    {
        Task<City> SearchCity(string cityname);
    }
}
