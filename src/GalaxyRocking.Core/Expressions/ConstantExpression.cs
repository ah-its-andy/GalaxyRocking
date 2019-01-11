namespace GalaxyRocking.Expressions
{
    public class ConstantExpression : UInt32Expression
    {
        public ConstantExpression(char symbol, uint value) : base(value)
        {
            Symbol = symbol;
        }

        public char Symbol { get; }
    }
}
