namespace GalaxyRocking.Expressions.SymbolResolvers
{
    /// <summary>
    /// 常量RepeatedExpression解析器
    /// </summary>
    public class ConstantRepeatResolver : RepeatedSymbolResolver
    {
        public override bool CanResolve(Expression current, Expression next)
        {
            //当前元素和下一个元素必须是字符数字表达式
            if (!(current is SymbolExpression currentExpr) || !(next is SymbolExpression nextExpr)) return false;
            //表达式的符号必须是可以重复的，并且左右的表达式符号必须一致
            if (!RepeatableSymbols.Contains(currentExpr.Symbol) || currentExpr.Symbol != nextExpr.Symbol) return false;

            return true;
        }

        public override (Expression, Expression) Resolve(Expression current, Expression next)
        {
            return (Expression.Repeat(current, next), null);
        }
    }
}
