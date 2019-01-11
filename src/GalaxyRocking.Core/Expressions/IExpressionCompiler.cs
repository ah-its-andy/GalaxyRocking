namespace GalaxyRocking.Expressions
{
    public interface IExpressionCompiler
    {
        GalaxyExpression Compile(string expressionString);
    }
}
