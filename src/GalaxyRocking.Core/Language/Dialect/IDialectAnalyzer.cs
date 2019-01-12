using System.Collections.Generic;

namespace GalaxyRocking.Language.Dialect
{
    public interface IDialectAnalyzer
    {
        List<Syntax> Analyze(string script);
    }
}