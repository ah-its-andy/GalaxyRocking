using GalaxyRocking.Symbol;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyRocking.Expressions
{
    /// <summary>
    /// 字符脚本解释引擎
    /// </summary>
    public class SymbolScriptEngine : ISymbolScriptEngine
    {
        private readonly ISymbolMappingService _symbolMappingService;
        private readonly IEnumerable<ISymbolResolver> _symbolResolvers;

        public SymbolScriptEngine(ISymbolMappingService symbolMappingService, IEnumerable<ISymbolResolver> symbolResolvers)
        {
            _symbolMappingService = symbolMappingService ?? throw new ArgumentNullException(nameof(symbolMappingService));
            _symbolResolvers = symbolResolvers ?? throw new ArgumentNullException(nameof(symbolResolvers));
        }

        /// <summary>
        /// 将字符脚本解释为表达式
        /// </summary>
        /// <param name="expressionString">字符脚本</param>
        /// <returns>银河系表达式</returns>
        public GalaxyExpression Interpret(string expressionString)
        {
            //将脚本转换为字符表达式集合
            var constExprs = expressionString.ToCharArray()
                .Select(x => new SymbolExpression(x, _symbolMappingService.GetDigitBySymbol(x)))
                .AsEnumerable<Expression>()
                .ToList();

            //定义默认的左侧表达式
            ArithmeticExpression currLeft = ArithmeticExpression.Zero;

            for (int i = 0; i < constExprs.Count; i++)
            {
                //如果当前元素是最后一个，则不需要处理
                if (i + 1 == constExprs.Count) continue;
                //获取当前元素
                var current = FindCurrent(constExprs, i);
                if (current.Item2 == null) continue;
                //获取下一个元素
                var next = constExprs[i + 1];
                //查找解析器
                var resolver = FindResolver(current.Item2, next);
                //如果找不到解析器， 则不处理
                if (resolver == null) continue;
                //解析元素关系，并替换原有的元素
                var resolveResult = resolver.Resolve(current.Item2, next);
                constExprs[current.Item1] = resolveResult.Item1;
                constExprs[i + 1] = resolveResult.Item2;
                //实例化下一级表达式树层
                currLeft = new AdditionExpression(currLeft, (ArithmeticExpression)resolveResult.Item1);
            }

            return new GalaxyExpression(currLeft);
        }


        private ISymbolResolver FindResolver(Expression left, Expression right)
        {
            return _symbolResolvers.FirstOrDefault(x => x.CanResolve(left, right));
        }

        private (int, Expression) FindCurrent(List<Expression> source, int index)
        {
            if (index < 0) return (index, null);
            var current = source[index];
            if (current != null) return (index, current);
            return FindCurrent(source, index - 1);
        }
    }
}
