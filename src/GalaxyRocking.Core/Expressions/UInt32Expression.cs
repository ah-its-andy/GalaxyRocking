namespace GalaxyRocking.Expressions
{
    public class UInt32Expression : ArithmeticExpression
    {
        public UInt32Expression(uint value)
        {
            Value = value;
        }

        public uint Value { get; }

        public override ArithmeticExpression Left => this;

        public override ArithmeticExpression Right => Zero;

        public override ArithmeticTypes ArithmeticType => ArithmeticTypes.UInt32;
    }
}
