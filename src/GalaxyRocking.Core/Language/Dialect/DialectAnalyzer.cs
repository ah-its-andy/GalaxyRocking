using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GalaxyRocking.Language.Dialect
{
    /// <summary>
    /// 方言分析器
    /// </summary>
    public class DialectAnalyzer : IDialectAnalyzer
    {
        private readonly GalaxyRockingOptions _galaxyRockingOptions;

        public DialectAnalyzer(GalaxyRockingOptions galaxyRockingOptions)
        {
            _galaxyRockingOptions = galaxyRockingOptions ?? throw new ArgumentNullException(nameof(galaxyRockingOptions));
        }

        /// <summary>
        /// 将方言分析称语法集合
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
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
