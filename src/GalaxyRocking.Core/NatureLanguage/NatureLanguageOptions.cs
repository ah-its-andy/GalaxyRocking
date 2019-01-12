using System.Collections.Generic;

namespace GalaxyRocking.NatureLanguage
{
    public class NatureLanguageOptions
    {
        public List<Feature> Features { get; } = new List<Feature>()
        {
            new Feature("(^how$)", FeatureTypes.Adverb),
            new Feature("(^many$)", FeatureTypes.Quantifier),
            new Feature("(^much$)", FeatureTypes.Quantifier),
            new Feature("(^Credits$)", FeatureTypes.Unit),
            new Feature("(^Silver$)", FeatureTypes.Unit),
            new Feature("(^Gold$)", FeatureTypes.Unit),
            new Feature("(^Iron$)", FeatureTypes.Unit),
            new Feature("(^is$)", FeatureTypes.Beverb),
            new Feature("(^\\?$)", FeatureTypes.Symbol),
            new Feature("(^\\d+$)", FeatureTypes.Digit),
            new Feature("(^C$)", FeatureTypes.ScriptSymbol),
            new Feature("(^I$)", FeatureTypes.ScriptSymbol),
            new Feature("(^V$)", FeatureTypes.ScriptSymbol),
            new Feature("(^X$)", FeatureTypes.ScriptSymbol),
            new Feature("(^L$)", FeatureTypes.ScriptSymbol),
            new Feature("(^D$)", FeatureTypes.ScriptSymbol),
            new Feature("(^M$)", FeatureTypes.ScriptSymbol),
        };
    }
}
