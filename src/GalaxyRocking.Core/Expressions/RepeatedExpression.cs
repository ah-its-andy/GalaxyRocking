using System;

namespace GalaxyRocking.Expressions
{
    /// <summary>
    /// 重复表达式，表示N个连续重复的字符
    /// </summary>
    public class RepeatedExpression : ArithmeticExpression
    {
        public RepeatedExpression(SymbolExpression left, SymbolExpression right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));
            if (left.Symbol != right.Symbol) throw new ArgumentOutOfRangeException();

            Left = left;
            RepeatTimes = 2;
        }

        /// <summary>
        /// 重复的次数
        /// </summary>
        public uint RepeatTimes { get; private set; }

        public override ArithmeticExpression Left { get; }

        public override ArithmeticExpression Right => new UInt32Expression(RepeatTimes);

        public override ArithmeticTypes ArithmeticType => ArithmeticTypes.Multiplication;

        public RepeatedExpression Add(SymbolExpression value)
        {            
            if (RepeatTimes == 3) throw new ArgumentOutOfRangeException("RepeatTimes");
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Symbol != ((SymbolExpression)Left).Symbol) throw new ArgumentOutOfRangeException();
            RepeatTimes++;
            return this;
        }
    }
}
