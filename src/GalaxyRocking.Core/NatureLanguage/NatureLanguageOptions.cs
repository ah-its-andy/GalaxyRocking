using System.Collections.Generic;

namespace GalaxyRocking.NatureLanguage
{
    public class NatureLanguageOptions
    {
        public List<Feature> Features { get; } = new List<Feature>()
        {
            new Feature("(^how\\smuch$)", FeatureTypes.Adverb),
            new Feature("(^how\\smany$)", FeatureTypes.Adverb),
            new Feature("(^Credits$)", FeatureTypes.Unit),
            new Feature("(^Silver$)", FeatureTypes.Unit),
            new Feature("(^Gold$)", FeatureTypes.Unit),
            new Feature("(^Iron$)", FeatureTypes.Unit),
            new Feature("(^is$)", FeatureTypes.Beverb),
            new Feature("(^\\?$)", FeatureTypes.Symbol),
            new Feature("(^\\d+$)", FeatureTypes.Digit),
            new Feature("(^C$)", FeatureTypes.RomanSymbol),
            new Feature("(^I$)", FeatureTypes.RomanSymbol),
            new Feature("(^V$)", FeatureTypes.RomanSymbol),
            new Feature("(^X$)", FeatureTypes.RomanSymbol),
            new Feature("(^L$)", FeatureTypes.RomanSymbol),
            new Feature("(^D$)", FeatureTypes.RomanSymbol),
            new Feature("(^M$)", FeatureTypes.RomanSymbol),
        };
    }
}
