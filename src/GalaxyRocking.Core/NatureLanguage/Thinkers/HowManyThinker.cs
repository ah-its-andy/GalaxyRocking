using GalaxyRocking.Expressions;
using GalaxyRocking.Language.Dialect;
using GalaxyRocking.UnitConvert;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GalaxyRocking.NatureLanguage.Thinkers
{
    /// <summary>
    /// 货币单位转换处理
    /// </summary>
    public class HowManyThinker : IThinker
    {
        public bool CanThink(Sentence sentence)
        {
            if (sentence.SentenceType != SentenceTypes.Question) return false;
            if (sentence.Words[0].FeatureType != FeatureTypes.Adverb) return false;
            if (sentence.Words[1].FeatureType != FeatureTypes.Quantifier) return false;
            if (sentence.Words[1].Body != "many") return false;
            if (sentence.Words[2].FeatureType != FeatureTypes.Unit) return false;
            if (sentence.Words[3].FeatureType != FeatureTypes.Beverb) return false;
            if (sentence.Words.Last().FeatureType != FeatureTypes.Symbol) return false;
            if (sentence.Words[sentence.Words.Count - 2].FeatureType != FeatureTypes.Unit) return false;


            return sentence.Words.Any(x => x.FeatureType == FeatureTypes.DialectDigit);

        }

        public Delegate Think(Sentence sentence)
        {
            return new Action<IServiceProvider>((provider) =>
            {
                var amount = string.Join(" ",
                        sentence.Words
                          .Where(x => x.FeatureType == FeatureTypes.DialectDigit)
                          .Select(x => x.Body));

                var dialectScriptEngine = provider.GetRequiredService<IDialectScriptEngine>();
                var symbolAmount = dialectScriptEngine.Interpret(amount);
                var symbolScriptEngine = provider.GetRequiredService<ISymbolScriptEngine>();
                var digitAmountExpr = symbolScriptEngine.Interpret(symbolAmount);

                var compiledDelegate = digitAmountExpr.Compile();

                var sourceUnit = sentence.Words[sentence.Words.Count - 2].Body;
                var targetUnit = sentence.Words[2].Body;

                var unitConverter = provider.GetRequiredService<IUnitConverter>();
                var convertedAmout = unitConverter.Convert((uint)compiledDelegate.DynamicInvoke(), sourceUnit, targetUnit);
                ConsolePrinter.PrintResult($"{amount} {sourceUnit} is {convertedAmout} {targetUnit}");
            });
        }
    }
}
