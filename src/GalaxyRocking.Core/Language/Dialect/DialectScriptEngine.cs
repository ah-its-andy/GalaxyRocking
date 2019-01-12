using System;
using System.Linq;

namespace GalaxyRocking.Language.Dialect
{
    public class DialectScriptEngine : IDialectScriptEngine
    {
        private readonly GalaxyRockingOptions _galaxyRockingOptions;
        private readonly IDialectAnalyzer _dialectAnalyzer;

        public DialectScriptEngine(GalaxyRockingOptions galaxyRockingOptions, IDialectAnalyzer dialectAnalyzer)
        {
            _galaxyRockingOptions = galaxyRockingOptions ?? throw new ArgumentNullException(nameof(galaxyRockingOptions));
            _dialectAnalyzer = dialectAnalyzer ?? throw new ArgumentNullException(nameof(dialectAnalyzer));
        }

        public string Interpret(string script)
        {
            var syntaxes = _dialectAnalyzer.Analyze(script);
            return string.Join("",
                syntaxes.Select(x =>
                    _galaxyRockingOptions.DialectOptions
                        .Mapping.First(kv => kv.Value == x.Content).Key));
        }
    }
}
