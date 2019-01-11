using GalaxyRocking.Expressions;
using GalaxyRocking.Expressions.SymbolResolvers;
using GalaxyRocking.Symbol;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GalaxyRocking
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGalaxyServices(this IServiceCollection services, Action<GalaxyRockingOptions> configure = null)
        {
            var options = new GalaxyRockingOptions();
            configure?.Invoke(options);
            services.AddSingleton(options);
            services.AddScoped<ISymbolMappingService, SymbolMappingService>();
            services.AddScoped<IExpressionCompiler, ExpressionCompiler>();
            services.AddScoped<ISymbolResolver, AddititionRepeatedResolver>();
            services.AddScoped<ISymbolResolver, ConstantRepeatResolver>();
            services.AddScoped<ISymbolResolver, ConstantSubtractResolver>();
            return services;
        }
    }
}
