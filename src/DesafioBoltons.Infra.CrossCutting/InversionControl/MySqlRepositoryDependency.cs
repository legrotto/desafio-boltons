using DesafioBoltons.Domain.Interfaces;
using DesafioBoltons.Infa.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioBoltons.Infra.CrossCutting.InversionOfControl
{
    public static class MySqlRepositoryDependency
    {
        public static void AddMySqlRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<INFeRepository, NFeRepository>();
        }
    }
}
