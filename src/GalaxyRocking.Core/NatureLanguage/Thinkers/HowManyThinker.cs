using GalaxyRocking.Expressions;
using GalaxyRocking.Language.Dialect;
using GalaxyRocking.UnitConvert;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyRocking.NatureLanguage.Thinkers
{
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
                ConsolePrinter.PrintVerbose($"罗马字表达式： {digitAmountExpr.ToString("S")}");
                ConsolePrinter.PrintVerbose($"十进制表达式： {digitAmountExpr.ToString("N")}");
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
