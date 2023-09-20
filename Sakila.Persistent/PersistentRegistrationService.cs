using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Sakila.Application.Contracts;
using Sakila.Persistent.Repositories;

namespace Sakila.Persistent
{
    public static  class PersistentRegistrationService
    {

        public static IServiceCollection ConfigurePersistenceRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SakilaContext>(x =>
            {
                string conectionString = configuration.GetConnectionString("sakila");
                MySqlServerVersion version = new(new Version(8, 0, 0));
                string conectStringMysql = "server=127.0.0.1;port=3306;database=sakila;user=root;password=123qwe@@AA";
                x.UseMySql(conectStringMysql, version);
            });
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<Application.Contracts.Actor.IActorRepository,Repositories.ActorRepository>();
            services.AddScoped<Application.Contracts.Citys.ICityRepository, Repositories.CityRepository>();
            return services;
        }

    }
}