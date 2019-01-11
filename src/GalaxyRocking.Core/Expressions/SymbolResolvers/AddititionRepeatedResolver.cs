namespace GalaxyRocking.Expressions.SymbolResolvers
{
    public class AddititionRepeatedResolver : RepeatedSymbolResolver
    {
        public override bool CanResolve(Expression current, Expression next)
        {
            if (!(current is RepeatedExpression currentExpr) || !(next is ConstantExpression nextExpr)) return false;
            if (((ConstantExpression)currentExpr.Left).Symbol != nextExpr.Symbol) return false;

            return true;
        }

        public override (Expression, Expression) Resolve(Expression current, Expression next)
        {
            return (((RepeatedExpression)current).Add((ConstantExpression)next), null);
        }
    }
}
