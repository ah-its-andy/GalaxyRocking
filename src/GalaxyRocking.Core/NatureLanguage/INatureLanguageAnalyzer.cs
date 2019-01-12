using System.Collections.Generic;

namespace GalaxyRocking.NatureLanguage
{
    public interface INatureLanguageAnalyzer
    {
        Sentence Analyze(string text);
    }
}