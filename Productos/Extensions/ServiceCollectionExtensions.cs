using core.Interfaces;
using core.Services;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Productos.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(options =>
             options.UseInMemoryDatabase("ProductosDb"));
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }


       
    }
}
