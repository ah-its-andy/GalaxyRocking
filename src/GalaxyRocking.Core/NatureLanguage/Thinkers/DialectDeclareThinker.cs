using GalaxyRocking.Language.Dialect;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GalaxyRocking.NatureLanguage.Thinkers
{
    public class DialectDeclareThinker : IThinker
    {
        public bool CanThink(Sentence sentence)
        {
            return sentence.SentenceType == SentenceTypes.Declarative
                && sentence.Words.Count == 3
                && sentence.Words[0].FeatureType == FeatureTypes.Text
                && sentence.Words[1].FeatureType == FeatureTypes.Beverb
                && sentence.Words[2].FeatureType == FeatureTypes.RomanSymbol;
        }

        public Delegate Think(Sentence sentence)
        {
            return new Action<IServiceProvider>((provider) =>
            {
                var galaxyRockingOpts = provider.GetRequiredService<GalaxyRockingOptions>();
                var dialectOpts = galaxyRockingOpts.DialectOptions;
                dialectOpts.Syntaxes.Add(new DialectFeature(sentence.Words[0].Body, false, SyntaxTypes.Keyword));
                dialectOpts.Mapping[Convert.ToChar(sentence.Words[2].Body)] = sentence.Words[0].Body;
                galaxyRockingOpts
                    .NatureLanguageOptions.Features
                        .Add(new Feature($"({sentence.Words[0].Body})", FeatureTypes.DialectDigit));
                ConsolePrinter.PrintVerbose($"Declare {sentence.Words[0].Body} as {sentence.Words[2].Body}.");
            });
        }
    }
}
