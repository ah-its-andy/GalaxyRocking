using GalaxyRocking.Symbol;
using System.Collections.Generic;

namespace GalaxyRocking.Expressions.SymbolResolvers
{
    public abstract class RepeatedSymbolResolver : ISymbolResolver
    {
        protected static readonly List<char> RepeatableSymbols = new List<char>
        {
            Symbols.I,
            Symbols.X,
            Symbols.C,
            Symbols.M
        };

        public abstract bool CanResolve(Expression current, Expression next);

        public abstract (Expression, Expression) Resolve(Expression current, Expression next);
    }
}
