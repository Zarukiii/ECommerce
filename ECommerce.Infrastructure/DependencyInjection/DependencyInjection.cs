using ECommerce.Application.Interfaces.Commands;
using ECommerce.Application.Interfaces.Queries;
using ECommerce.Application.Services.ProductServices.Commands;
using ECommerce.Application.Services.ProductServices.Queries;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Repositories.Commands;
using ECommerce.Infrastructure.Repositories.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductCommandService, ProductCommandService>();
            services.AddScoped<IProductQueryService, ProductQueryService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<AppDbContext>(options =>
            
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.MigrationsAssembly("ECommerce.Infrastructure"))
            );

            return services;
        }
    }
}
