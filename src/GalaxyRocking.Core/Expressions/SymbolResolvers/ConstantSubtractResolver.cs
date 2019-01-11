namespace GalaxyRocking.Expressions.SymbolResolvers
{
    public class ConstantSubtractResolver : SubtractSymbolResolver
    {
        public override bool CanResolve(Expression current, Expression next)
        {
            if (!(current is ConstantExpression currentExpr) || !(next is ConstantExpression nextExpr)) return false;
            return IsSubtractable(currentExpr.Symbol, nextExpr.Symbol);
        }

        public override (Expression, Expression) Resolve(Expression current, Expression next)
        {
            return (Expression.Subtract(current, next), null);
        }
    }
}
