using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quotation.Application.Repositories.Interface;
using Quotation.Infrastructure.Data;
using Quotation.Infrastructure.Repository;


namespace Quotation.Infrastructure.Configuration
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QuotationDbContext>(
                   opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly("Quotation.Infrastructure")));

            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            return services;
        }
    }
}
