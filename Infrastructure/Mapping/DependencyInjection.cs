// En Infrastructure/DependencyInjection.cs
using core.Interfaces;
using Infrastructure.Mapping;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Mapping
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            // Opción 1: Si tus Profile están en Infrastructure
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddScoped<IMappingService, MappingService>(); // Registra tu wrapper
            // Opción 2: Especifica el tipo de cualquier clase en el assembly
            // Ej: services.AddAutoMapper(typeof(UserMappings).Assembly);

            return services;
        }

    }


}
