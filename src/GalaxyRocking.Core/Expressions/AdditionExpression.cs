using System;

namespace GalaxyRocking.Expressions
{
    /// <summary>
    /// 加法表达式
    /// </summary>
    public class AdditionExpression : ArithmeticExpression
    {
        /// <summary>
        /// 实例化一个加法表达式对象
        /// </summary>
        /// <param name="left">加法表达式左侧的元素</param>
        /// <param name="right">加法表达式右侧的元素</param>
        public AdditionExpression(ArithmeticExpression left, ArithmeticExpression right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }

        /// <summary>
        /// 加法表达式左侧的元素
        /// </summary>
        public override ArithmeticExpression Left { get; }

        /// <summary>
        /// 加法表达式右侧的元素
        /// </summary>
        public override ArithmeticExpression Right { get; }

        public override ArithmeticTypes ArithmeticType => ArithmeticTypes.Addition;

    }
}
