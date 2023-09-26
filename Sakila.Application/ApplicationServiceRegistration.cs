using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using FluentValidation;
using Sakila.Application.Dtos.Actors.Validators;

namespace Sakila.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigurateApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
           // services.AddScoped<IValidator<Dtos.Actors.CreateActor>, CreateActorValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateActorValidator>();
            return services;
        }
    }
}