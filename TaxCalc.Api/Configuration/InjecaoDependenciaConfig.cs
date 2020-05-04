using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaxCalc.Business.Interface;
using TaxCalc.Business.Services;

namespace TaxCalc.Api.Configuration
{
    public static class InjecaoDependenciaConfig
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<ICalculoService, CalculoService>();
            services.AddScoped<IInfoService, InfoService>();

            services.AddScoped<IMediator, Mediator>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSwaggerGen();

            return services;
        }
    }
}
