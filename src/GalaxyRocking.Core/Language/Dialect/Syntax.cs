using System;

namespace GalaxyRocking.Language.Dialect
{
    public class Syntax
    {
        public Syntax(string content, SyntaxTypes syntaxType)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
            SyntaxType = syntaxType;
        }

        public string Content { get; }
        public SyntaxTypes SyntaxType { get; }
    }
}
