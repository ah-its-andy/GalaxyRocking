using System;

namespace GalaxyRocking.Expressions
{
    /// <summary>
    /// 减法表达式
    /// </summary>
    public class SubtractedExpression : ArithmeticExpression
    {
        public SubtractedExpression(SymbolExpression left, SymbolExpression right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }
        
        public override ArithmeticExpression Left { get; }
        
        public override ArithmeticExpression Right { get; }

        public override ArithmeticTypes ArithmeticType => ArithmeticTypes.Subtraction;
    }
}
