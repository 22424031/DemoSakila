﻿using Microsoft.Extensions.Configuration;
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
            string conectionString = configuration.GetConnectionString("sakila");
            services.AddDbContext<SakilaContext>(x =>
            {
                MySqlServerVersion version = new(new Version(8, 0, 0));
                x.UseMySql(conectionString, version);
            });
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<Application.Contracts.Actor.IActorRepository,Repositories.ActorRepository>();
            services.AddScoped<Application.Contracts.Citys.ICityRepository, Repositories.CityRepository>();
            return services;
        }

    }
}