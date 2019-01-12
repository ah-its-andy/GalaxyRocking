using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyRocking.NatureLanguage
{
    /// <summary>
    /// 句子
    /// </summary>
    public class Sentence
    {
        public Sentence(List<Word> words)
        {
            Words = words ?? throw new ArgumentNullException(nameof(words));
            SentenceType =
                words.Any(x => x.FeatureType == FeatureTypes.Symbol && x.Body == "?")
                  ? SentenceTypes.Question : SentenceTypes.Declarative;
        }

        public SentenceTypes SentenceType { get; }
        public List<Word> Words { get; }
    }
}
