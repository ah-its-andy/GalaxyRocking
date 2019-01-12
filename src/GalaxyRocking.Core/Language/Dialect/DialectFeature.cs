using System;

namespace GalaxyRocking.Language.Dialect
{
    public class DialectFeature
    {
        public DialectFeature(string expression, bool useRegular, SyntaxTypes syntaxType)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            UseRegular = useRegular;
            SyntaxType = syntaxType;
        }

        public string Expression { get; }
        public bool UseRegular { get; }
        public SyntaxTypes SyntaxType { get; }
    }
}
