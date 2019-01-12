using GalaxyRocking.Symbol;
using System.Collections.Generic;

namespace GalaxyRocking.Expressions.SymbolResolvers
{
    public abstract class SubtractSymbolResolver : ISymbolResolver
    {
        /// <summary>
        /// 可以做减法的字符对照表
        /// </summary>
        protected readonly Dictionary<char, List<char>> SubtracableCharMap
            = new Dictionary<char, List<char>>
            {
                [Symbols.I] = new List<char> { Symbols.V, Symbols.X },
                [Symbols.X] = new List<char> { Symbols.L, Symbols.C },
                [Symbols.C] = new List<char> { Symbols.D, Symbols.M }
            };


        /// <summary>
        /// 判断字符是否可以做减法
        /// </summary>
        /// <param name="left">SubtractedExpression左侧的常量</param>
        /// <param name="right">SubtractedExpression右侧的常量</param>
        /// <returns></returns>
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
