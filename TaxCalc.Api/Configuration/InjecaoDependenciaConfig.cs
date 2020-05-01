using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TaxCalc.Business.Interface;
using TaxCalc.Business.Services;

namespace TaxCalc.Api.Configuration
{
    public static class InjecaoDependenciaConfig
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<ICalculosService, CalculosService>();
            services.AddScoped<IInfoService, InfoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSwaggerGen();

            return services;
        }
    }
}
