using System;
using System.Text.RegularExpressions;

namespace GalaxyRocking.NatureLanguage
{
    public class Feature
    {
        public Feature(string regularString, FeatureTypes type)
        {
            RegularString = regularString ?? throw new ArgumentNullException(nameof(regularString));
            Type = type;
        }

        public string RegularString { get; }
        public FeatureTypes Type { get; }
        public Regex Regular => new Regex(RegularString);
    }
}
