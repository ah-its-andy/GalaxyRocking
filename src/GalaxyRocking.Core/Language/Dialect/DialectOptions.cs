using GalaxyRocking.Symbol;
using System.Collections.Generic;

namespace GalaxyRocking.Language.Dialect
{
    public class DialectOptions
    {
        public List<DialectFeature> Syntaxes { get; set; } = new List<DialectFeature>
        {
            //new DialectFeature("glob", false, SyntaxTypes.Keyword),
            //new DialectFeature("prok", false, SyntaxTypes.Keyword),
            //new DialectFeature("pish", false, SyntaxTypes.Keyword),
            //new DialectFeature("tegj", false, SyntaxTypes.Keyword),
            //new DialectFeature("Silver", false, SyntaxTypes.Unit),
            //new DialectFeature("Gold", false, SyntaxTypes.Unit),
            //new DialectFeature("Iron", false, SyntaxTypes.Unit),
            //new DialectFeature("Credits", false, SyntaxTypes.Unit),
            //new DialectFeature("is", false, SyntaxTypes.Operator),
            //new DialectFeature("much", false, SyntaxTypes.Operator),
            //new DialectFeature("many", false, SyntaxTypes.Operator),
            //new DialectFeature("\\d+", true, SyntaxTypes.Digit)
        };

        public Dictionary<char, string> Mapping { get; set; } = new Dictionary<char, string>
        {
            //[Symbols.I]="glob",
            //[Symbols.V]="prok",
            //[Symbols.X]="pish",
            //[Symbols.L]="tegj"
        };
    }
}
