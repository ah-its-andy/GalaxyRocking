using System;
using System.Linq;

namespace GalaxyRocking.Language.Dialect
{
    /// <summary>
    /// 方言解释引擎
    /// </summary>
    public class DialectScriptEngine : IDialectScriptEngine
    {
        private readonly GalaxyRockingOptions _galaxyRockingOptions;
        private readonly IDialectAnalyzer _dialectAnalyzer;

        public DialectScriptEngine(GalaxyRockingOptions galaxyRockingOptions, IDialectAnalyzer dialectAnalyzer)
        {
            _galaxyRockingOptions = galaxyRockingOptions ?? throw new ArgumentNullException(nameof(galaxyRockingOptions));
            _dialectAnalyzer = dialectAnalyzer ?? throw new ArgumentNullException(nameof(dialectAnalyzer));
        }

        /// <summary>
        /// 将方言解释为字符脚本
        /// </summary>
        /// <param name="script">方言</param>
        /// <returns>字符脚本</returns>
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
