using System.Collections.Generic;

namespace GalaxyRocking.Expressions
{
    public interface ISymbolResolver
    {
        bool CanResolve(Expression current, Expression next);
        (Expression, Expression) Resolve(Expression current, Expression next);
    }
}
