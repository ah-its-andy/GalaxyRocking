using System;

namespace GalaxyRocking.Expressions
{
    public class Expression
    {
        /// <summary>
        /// 创建一个SubtractedExpression
        /// </summary>
        /// <param name="left">表达式左侧的元素</param>
        /// <param name="right">表达式右侧的元素</param>
        /// <returns>SubtractedExpression</returns>
        public static Expression Subtract(Expression left, Expression right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));
            if (!(left is SymbolExpression)) throw new ArgumentTypeDismatchException(nameof(left));
            if (!(right is SymbolExpression)) throw new ArgumentTypeDismatchException(nameof(right));

            return new SubtractedExpression((SymbolExpression)left, (SymbolExpression)right);
        }

        /// <summary>
        /// 创建一个RepeatedExpression
        /// </summary>
        /// <param name="left">表达式左侧的元素，可以是 SymbolExpression 或 RepeatedExpression</param>
        /// <param name="right">表达式右侧的元素</param>
        /// <returns>RepeatedExpression</returns>
        public static Expression Repeat(Expression left, Expression right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));
            if (!(left is SymbolExpression) && !(left is RepeatedExpression)) throw new ArgumentTypeDismatchException(nameof(left));
            if (!(right is SymbolExpression)) throw new ArgumentTypeDismatchException(nameof(right));

            if(left is SymbolExpression)
            {
                return new RepeatedExpression((SymbolExpression)left, (SymbolExpression)right);
            }
            return ((RepeatedExpression)left).Add((SymbolExpression)right);
        }
    }
}
