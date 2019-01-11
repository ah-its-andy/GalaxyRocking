namespace GalaxyRocking.Expressions
{
    public abstract class ArithmeticExpression : Expression
    {
        public readonly static ArithmeticExpression Zero = new ZeroExpression();

        public abstract ArithmeticExpression Left { get; }
        public abstract ArithmeticExpression Right { get; }
        public abstract ArithmeticTypes ArithmeticType { get; }
        
        private class ZeroExpression : ArithmeticExpression
        {
            public override ArithmeticExpression Left => null;

            public override ArithmeticExpression Right => null;

            public override ArithmeticTypes ArithmeticType => ArithmeticTypes.Zero;
        }
    }
}
