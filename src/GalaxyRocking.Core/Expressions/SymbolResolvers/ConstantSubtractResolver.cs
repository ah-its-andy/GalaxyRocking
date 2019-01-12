namespace GalaxyRocking.Expressions.SymbolResolvers
{
    /// <summary>
    /// 常量SubtractedExpression解析器
    /// </summary>
    public class ConstantSubtractResolver : SubtractSymbolResolver
    {
        public override bool CanResolve(Expression current, Expression next)
        {
            //表达式左右两侧都必须是字符数字表达式
            if (!(current is SymbolExpression currentExpr) || !(next is SymbolExpression nextExpr)) return false;
            return IsSubtractable(currentExpr.Symbol, nextExpr.Symbol);
        }

        public override (Expression, Expression) Resolve(Expression current, Expression next)
        {
            return (Expression.Subtract(current, next), null);
        }
    }
}
