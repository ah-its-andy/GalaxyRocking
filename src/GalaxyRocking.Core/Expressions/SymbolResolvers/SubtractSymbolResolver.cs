using GalaxyRocking.Symbol;
using System.Collections.Generic;

namespace GalaxyRocking.Expressions.SymbolResolvers
{
    public abstract class SubtractSymbolResolver : ISymbolResolver
    {
        protected readonly Dictionary<char, List<char>> SubtracableCharMap
            = new Dictionary<char, List<char>>
            {
                [Symbols.I] = new List<char> { Symbols.V, Symbols.X },
                [Symbols.X] = new List<char> { Symbols.L, Symbols.C },
                [Symbols.C] = new List<char> { Symbols.D, Symbols.M }
            };


        protected bool IsSubtractable(char left, char right)
        {
            if (!SubtracableCharMap.ContainsKey(left)) return false;
            if (!SubtracableCharMap[left].Contains(right)) return false;
            return true;
        }

        public abstract bool CanResolve(Expression current, Expression next);
        public abstract (Expression, Expression) Resolve(Expression current, Expression next);
    }
}
