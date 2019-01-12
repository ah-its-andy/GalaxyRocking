using GalaxyRocking.Symbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyRocking.Expressions
{
    public class SymbolScriptEngine : ISymbolScriptEngine
    {
        private readonly ISymbolMappingService _symbolMappingService;
        private readonly IEnumerable<ISymbolResolver> _symbolResolvers;

        public SymbolScriptEngine(ISymbolMappingService symbolMappingService, IEnumerable<ISymbolResolver> symbolResolvers)
        {
            _symbolMappingService = symbolMappingService ?? throw new ArgumentNullException(nameof(symbolMappingService));
            _symbolResolvers = symbolResolvers ?? throw new ArgumentNullException(nameof(symbolResolvers));
        }

        public GalaxyExpression Interpret(string expressionString)
        {
            var constExprs = expressionString.ToCharArray()
                .Select(x => new ConstantExpression(x, _symbolMappingService.GetDigitBySymbol(x)))
                .AsEnumerable<Expression>()
                .ToList();

            ArithmeticExpression currLeft = ArithmeticExpression.Zero;

            for (int i = 0; i < constExprs.Count; i++)
            {
                if (i + 1 == constExprs.Count) continue;
                var current = FindCurrent(constExprs, i);
                var next = constExprs[i + 1];
                var resolver = FindResolver(current, next);
                if (resolver == null) continue;
                var resolveResult = resolver.Resolve(current, next);
                constExprs[i] = resolveResult.Item1;
                constExprs[i + 1] = resolveResult.Item2;
                currLeft = new AdditionExpression(currLeft, (ArithmeticExpression)resolveResult.Item1);
            }

            return new GalaxyExpression(currLeft);
        }

        private ISymbolResolver FindResolver(Expression left, Expression right)
        {
            return _symbolResolvers.FirstOrDefault(x => x.CanResolve(left, right));
        }

        private Expression FindCurrent(List<Expression> source, int index)
        {
            if (index < 0) return null;
            var current = source[index];
            if (current != null) return current;
            return FindCurrent(source, index - 1);
        }
    }
}
