using System;
using System.Linq;

namespace GalaxyRocking.NatureLanguage
{
    /// <summary>
    /// 自然语言分析器
    /// </summary>
    public class NatureLanguageAnalyzer : INatureLanguageAnalyzer
    {
        private readonly GalaxyRockingOptions _galaxyRockingOptions;

        public NatureLanguageAnalyzer(GalaxyRockingOptions galaxyRockingOptions)
        {
            _galaxyRockingOptions = galaxyRockingOptions ?? throw new ArgumentNullException(nameof(galaxyRockingOptions));
        }

        public Sentence Analyze(string text)
        {
            return new Sentence(text.Split(' ')
                .Where(x=> !string.IsNullOrEmpty(x))
                .Select(x => CreateWord(x))
                .ToList());
        }

        private Word CreateWord(string text)
        {
            var feature = _galaxyRockingOptions
                .NatureLanguageOptions
                    .Features
                        .FirstOrDefault(x => x.Regular.IsMatch(text));
            if (feature == null) return new Word(FeatureTypes.Text, text);
            return new Word(feature.Type, feature.Regular.Match(text).Groups[0].Value);
        }
    }
}
