using System;

namespace GalaxyRocking.Expressions
{
    public class RepeatedExpression : ArithmeticExpression
    {
        public RepeatedExpression(ConstantExpression left, ConstantExpression right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));
            if (left.Symbol != right.Symbol) throw new ArgumentOutOfRangeException();

            Left = left;
            RepeatTimes = 2;
        }

        public uint RepeatTimes { get; private set; }

        public override ArithmeticExpression Left { get; }

        public override ArithmeticExpression Right => new UInt32Expression(RepeatTimes);

        public override ArithmeticTypes ArithmeticType => ArithmeticTypes.Multiplication;

        public RepeatedExpression Add(ConstantExpression value)
        {            
            if (RepeatTimes == 3) throw new ArgumentOutOfRangeException("RepeatTimes");
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Symbol != ((ConstantExpression)Left).Symbol) throw new ArgumentOutOfRangeException();
            RepeatTimes++;
            return this;
        }
    }
}
