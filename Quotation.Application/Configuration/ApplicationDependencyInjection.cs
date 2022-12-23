using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Quotation.Application.Services;
using Quotation.Application.Services.Interfaces;
using Quotation.Application.Validators;
using System;
using System.Reflection;


namespace Quotation.Application.Configuration
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<UnitModelValidator>();

            services.AddSingleton(GetConfiguredMappingConfig());
            services.AddScoped<IMapper, ServiceMapper>();
            // here register services
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IStateService, StateService>();
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
