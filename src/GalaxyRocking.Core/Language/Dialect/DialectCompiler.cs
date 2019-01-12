using GalaxyRocking.Expressions;
using GalaxyRocking.UnitConvert;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GalaxyRocking.Language.Dialect
{
    public class DialectCompiler : IDialectCompiler
    {
        private readonly IServiceProvider _serviceProvider;

        public DialectCompiler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
        //glob glob Silver is 34 Credits
        //how much is pish tegj glob glob ?
        //how many Credits is glob prok Silver ?
        private readonly static Regex PutMappingRegular = new Regex("([a-z]+)(\\s)(is)(\\s)([A-Z]{1})");
        private readonly static Regex UnitMappingRegular = new Regex("([a-z\\s]+)(Silver|Gold|Iron)(\\s)(is)(\\s)(\\d+)(\\s)(Credits)");
        private readonly static Regex HowMuchRegular = new Regex("(how\\smuch)(\\s)(is)(\\s)([a-z\\s]+)(\\?)");
        private readonly static Regex HowManyRegular = new Regex("(how\\smany)(\\s)(Credits)(\\s)(is)(\\s)([a-z\\s]+)(Silver|Gold|Iron)(\\s)(\\?)");

        public Delegate Compile(string script)
        {
            if (PutMappingRegular.IsMatch(script))
            {
                var index = script.IndexOf("is");
                return new Func<IServiceProvider, object>(
                    (provider) =>
                        provider.GetRequiredService<GalaxyRockingOptions>()
                            .DialectOptions
                               .Mapping[Convert.ToChar(script.Substring(index + 2, 1))]
                                 = script.Substring(0, index - 1));
            }
            else if(UnitMappingRegular.IsMatch(script))
            {
                var matchedScript = UnitMappingRegular.Match(script);
                return new Func<IServiceProvider, object>(
                    (provider) =>
                    {
                        var dialectScriptEngine = provider.GetRequiredService<IDialectScriptEngine>();
                        var symbolScriptEngine = provider.GetRequiredService<ISymbolScriptEngine>();
                        var amount = matchedScript.Groups[1].Value;
                        var symbolAmount = dialectScriptEngine.Interpret(amount);
                        var digitAmount = symbolScriptEngine.Interpret(symbolAmount).Compile().DynamicInvoke();
                        var unitName = matchedScript.Groups[2].Value;
                        var creditsAmount = Convert.ToUInt32(matchedScript.Groups[6].Value);
                        provider.GetRequiredService<GalaxyRockingOptions>()
                            .UnitConvertOptions
                            .UnitConvertDescriptors.Add(
                                new UnitConvertDescriptor((uint)digitAmount, unitName, creditsAmount));
                        Console.WriteLine($"{digitAmount} {unitName} = {creditsAmount} Credits");
                        return null;
                    });
            }
            else if (HowMuchRegular.IsMatch(script))
            {
                return new Func<IServiceProvider, object>((provider) =>
                {
                    var dialectScriptEngine = provider.GetRequiredService<IDialectScriptEngine>();
                    var symbolScriptEngine = provider.GetRequiredService<ISymbolScriptEngine>();
                    var amount = HowMuchRegular.Match(script).Groups[5].Value;
                    var symbolAmount = dialectScriptEngine.Interpret(amount);
                    var digitAmount = symbolScriptEngine.Interpret(symbolAmount).Compile().DynamicInvoke();
                    Console.WriteLine($"{amount} is {digitAmount} Credits");
                    return null;
                });
            }
            else if (HowManyRegular.IsMatch(script))
            {
                return new Func<IServiceProvider, object>((provider) =>
                {
                    var dialectScriptEngine = provider.GetRequiredService<IDialectScriptEngine>();
                    var symbolScriptEngine = provider.GetRequiredService<ISymbolScriptEngine>();
                    var unitConverter = provider.GetRequiredService<IUnitConverter>();
                    var match = HowManyRegular.Match(script);
                    var targetUnitName = match.Groups[3].Value;
                    var amount = match.Groups[7].Value;
                    var sourceUnitName = match.Groups[8].Value;
                    var symbolAmount = dialectScriptEngine.Interpret(amount);
                    var digitAmount = symbolScriptEngine.Interpret(symbolAmount).Compile().DynamicInvoke();
                    var convertedAmount = unitConverter.Convert((uint)digitAmount, sourceUnitName, targetUnitName);
                    Console.WriteLine($"{amount} {sourceUnitName} is {convertedAmount} {targetUnitName}");
                    return null;
                });
            }
            return null;
        }
    }
}
