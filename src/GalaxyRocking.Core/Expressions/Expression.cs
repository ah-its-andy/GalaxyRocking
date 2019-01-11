using System;

namespace GalaxyRocking.Expressions
{
    public class Expression
    {
        public static Expression Subtract(Expression left, Expression right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));
            if (!(left is ConstantExpression)) throw new ArgumentTypeDismatchException(nameof(left));
            if (!(right is ConstantExpression)) throw new ArgumentTypeDismatchException(nameof(right));

            return new SubtractedExpression((ConstantExpression)left, (ConstantExpression)right);
        }

        public static Expression Repeat(Expression left, Expression right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));
            if (!(left is ConstantExpression) && !(left is RepeatedExpression)) throw new ArgumentTypeDismatchException(nameof(left));
            if (!(right is ConstantExpression)) throw new ArgumentTypeDismatchException(nameof(right));

            if(left is ConstantExpression)
            {
                return new RepeatedExpression((ConstantExpression)left, (ConstantExpression)right);
            }
            return ((RepeatedExpression)left).Add((ConstantExpression)right);
        }
    }
}
