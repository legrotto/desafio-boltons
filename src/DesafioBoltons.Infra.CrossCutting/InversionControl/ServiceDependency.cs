using DesafioBoltons.Domain.Interfaces;
using DesafioBoltons.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioBoltons.Infra.CrossCutting.InversionOfControl
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<INFeService, NFeService>();            
        }
    }
}
