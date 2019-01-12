using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GalaxyRocking.Language.Dialect
{
    public class DialectAnalyzer : IDialectAnalyzer
    {
        private readonly GalaxyRockingOptions _galaxyRockingOptions;

        public DialectAnalyzer(GalaxyRockingOptions galaxyRockingOptions)
        {
            _galaxyRockingOptions = galaxyRockingOptions ?? throw new ArgumentNullException(nameof(galaxyRockingOptions));
        }

        public List<Syntax> Analyze(string script)
        {
            return script.Split(' ')
                .Select(x =>
                {
                    var feature =
                        _galaxyRockingOptions.DialectOptions.Syntaxes
                            .FirstOrDefault(f =>
                                f.UseRegular ?
                                    new Regex(f.Expression).IsMatch(x) : f.Expression == x);
                    if (feature == null) return null;
                    return new Syntax(x, feature.SyntaxType);
                })
                .Where(x => x != null)
                .ToList();
        }
    }
}
