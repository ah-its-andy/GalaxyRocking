using GalaxyRocking.Expressions;
using GalaxyRocking.Language.Dialect;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GalaxyRocking.NatureLanguage.Thinkers
{
    /// <summary>
    /// 字符脚本解释处理
    /// </summary>
    public class HowMuchThinker : IThinker
    {
        public bool CanThink(Sentence sentence)
        {
            if (sentence.SentenceType != SentenceTypes.Question) return false;
            if (sentence.Words[0].FeatureType != FeatureTypes.Adverb) return false;
            if (sentence.Words[1].FeatureType != FeatureTypes.Quantifier) return false;
            if (sentence.Words[1].Body != "much") return false;
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

                ConsolePrinter.PrintResult($"{amount} is {compiledDelegate.DynamicInvoke()}");
            });
        }
    }
}
