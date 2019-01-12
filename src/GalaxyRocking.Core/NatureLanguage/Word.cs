using System;

namespace GalaxyRocking.NatureLanguage
{
    public class Word
    {
        public Word(FeatureTypes featureType, string body)
        {
            FeatureType = featureType;
            Body = body ?? throw new ArgumentNullException(nameof(body));
        }

        public FeatureTypes FeatureType { get; }
        public string Body { get; }
    }
}
