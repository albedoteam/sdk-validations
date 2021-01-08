using System;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AlbedoTeam.Sdk.Validations
{
    public static class Setup
    {
        public static IServiceCollection AddValidators(this IServiceCollection services, string applicationAssemblyName)
        {
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            return services;
        }
    }
}