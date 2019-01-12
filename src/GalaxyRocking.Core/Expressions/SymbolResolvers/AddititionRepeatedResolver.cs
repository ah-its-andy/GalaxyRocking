namespace GalaxyRocking.Expressions.SymbolResolvers
{
    /// <summary>
    /// 向RepeatedExpression追加成员的解析器
    /// </summary>
    public class AddititionRepeatedResolver : RepeatedSymbolResolver
    {
        public override bool CanResolve(Expression current, Expression next)
        {
            //必须当前元素是RepeatedExpression，且下一个元素是字符数字表达式
            if (!(current is RepeatedExpression currentExpr) || !(next is SymbolExpression nextExpr)) return false;
            //表达式符号必须一致
            if (((SymbolExpression)currentExpr.Left).Symbol != nextExpr.Symbol) return false;

            return true;
        }

        public override (Expression, Expression) Resolve(Expression current, Expression next)
        {
            return (((RepeatedExpression)current).Add((SymbolExpression)next), null);
        }
    }
}
