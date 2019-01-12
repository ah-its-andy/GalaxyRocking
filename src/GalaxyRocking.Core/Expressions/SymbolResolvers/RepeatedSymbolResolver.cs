using GalaxyRocking.Symbol;
using System.Collections.Generic;

namespace GalaxyRocking.Expressions.SymbolResolvers
{
    /// <summary>
    /// RepeatedExpression的抽象基类
    /// </summary>
    public abstract class RepeatedSymbolResolver : ISymbolResolver
    {
        /// <summary>
        /// 支持RepeatedExpression的符号
        /// </summary>
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
