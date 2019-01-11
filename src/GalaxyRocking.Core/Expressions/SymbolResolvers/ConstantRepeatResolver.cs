namespace GalaxyRocking.Expressions.SymbolResolvers
{
    public class ConstantRepeatResolver : RepeatedSymbolResolver
    {
        public override bool CanResolve(Expression current, Expression next)
        {
            if (!(current is ConstantExpression currentExpr) || !(next is ConstantExpression nextExpr)) return false;
            if (!RepeatableSymbols.Contains(currentExpr.Symbol) || currentExpr.Symbol != nextExpr.Symbol) return false;

            return true;
        }

        public override (Expression, Expression) Resolve(Expression current, Expression next)
        {
            return (Expression.Repeat(current, next), null);
        }
    }
}
