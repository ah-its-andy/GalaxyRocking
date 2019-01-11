using System;

namespace GalaxyRocking.Expressions
{
    public class SubtractedExpression : ArithmeticExpression
    {
        public SubtractedExpression(ConstantExpression left, ConstantExpression right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }
        
        public override ArithmeticExpression Left { get; }
        
        public override ArithmeticExpression Right { get; }

        public override ArithmeticTypes ArithmeticType => ArithmeticTypes.Subtraction;
    }
}
