using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Quotation.Application.Interface;
using Quotation.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Configuration
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddSingleton(GetConfiguredMappingConfig());
            services.AddScoped<IMapper, ServiceMapper>();

            services.AddScoped<IUnitService, UnitService>();
            return services;
        }


        /// <summary>
        /// Mapster(Mapper) global configuration settings
        /// To learn more about Mapster,
        /// see https://github.com/MapsterMapper/Mapster
        /// </summary>
        /// <returns></returns>
        private static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            IList<IRegister> registers = config.Scan(Assembly.GetExecutingAssembly());

            config.Apply(registers);

            return config;
        }
    }
}
