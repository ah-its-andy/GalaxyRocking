using GalaxyRocking.Expressions;
using GalaxyRocking.Language.Dialect;
using GalaxyRocking.UnitConvert;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GalaxyRocking.NatureLanguage.Thinkers
{
    /// <summary>
    /// 单位定义处理
    /// </summary>
    public class UnitDelcareThinker : IThinker
    {
        public bool CanThink(Sentence sentence)
        {
            try
            {
                if (sentence.SentenceType != SentenceTypes.Declarative) return false;

                var beverbWord = sentence.Words
                    .Select((e, i) => new { e, i })
                    .FirstOrDefault(x => x.e.FeatureType == FeatureTypes.Beverb);
                if (beverbWord == null) return false;
                var beverbIndex = beverbWord.i;
                var unitNameIndex = beverbIndex - 1;
                var creditsDigitIndex = beverbIndex + 1;

                if (sentence.Words[beverbIndex - 1].FeatureType != FeatureTypes.Unit) return false;
                if (sentence.Words[beverbIndex + 1].FeatureType != FeatureTypes.Digit) return false;
                if (sentence.Words[beverbIndex + 2].FeatureType != FeatureTypes.Unit) return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Delegate Think(Sentence sentence)
        {
            return new Action<IServiceProvider>((provider) =>
            {
                var beverbWord = sentence.Words
                    .Select((e, i) => new { e, i })
                    .First(x => x.e.FeatureType == FeatureTypes.Beverb);

                var amount = string.Join(" ", sentence.Words.Take(beverbWord.i - 1).Select(x => x.Body));

                var dialectScriptEngine = provider.GetRequiredService<IDialectScriptEngine>();
                var symbolAmount = dialectScriptEngine.Interpret(amount);

                var symbolScriptEngine = provider.GetRequiredService<ISymbolScriptEngine>();
                var digitAmount = symbolScriptEngine.Interpret(symbolAmount).Compile().DynamicInvoke();

                var galaxyRockingOpts = provider.GetRequiredService<GalaxyRockingOptions>();
                galaxyRockingOpts.UnitConvertOptions
                    .UnitConvertDescriptors
                        .Add(new UnitConvertDescriptor(
                            (uint)digitAmount,                            
                            sentence.Words[beverbWord.i - 1].Body,
                            Convert.ToUInt32(sentence.Words[beverbWord.i + 1].Body)
                            ));
                ConsolePrinter.PrintVerbose($"Declare unit " +
                    $"{digitAmount} " +
                    $"{sentence.Words[beverbWord.i - 1].Body} as " +
                    $"{sentence.Words[beverbWord.i + 1].Body} Credits");
            });
        }
    }
}
