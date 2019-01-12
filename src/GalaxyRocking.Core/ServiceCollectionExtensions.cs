using GalaxyRocking.Expressions;
using GalaxyRocking.Expressions.SymbolResolvers;
using GalaxyRocking.Language.Dialect;
using GalaxyRocking.NatureLanguage;
using GalaxyRocking.NatureLanguage.Thinkers;
using GalaxyRocking.Symbol;
using GalaxyRocking.UnitConvert;
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
            services.AddScoped<ISymbolScriptEngine, SymbolScriptEngine>();
            services.AddScoped<ISymbolResolver, AddititionRepeatedResolver>();
            services.AddScoped<ISymbolResolver, ConstantRepeatResolver>();
            services.AddScoped<ISymbolResolver, ConstantSubtractResolver>();
            services.AddScoped<IDialectAnalyzer, DialectAnalyzer>();
            services.AddScoped<IDialectScriptEngine, DialectScriptEngine>();

            services.AddScoped<INatureLanguageAnalyzer, NatureLanguageAnalyzer>();
            services.AddScoped<IThinker, DialectDeclareThinker>();
            services.AddScoped<IThinker, UnitDelcareThinker>();
            services.AddScoped<IThinker, HowMuchThinker>();
            services.AddScoped<IThinker, HowManyThinker>();

            services.AddScoped<IUnitConverter, UnitConverter>();

            return services;
        }
    }
}
