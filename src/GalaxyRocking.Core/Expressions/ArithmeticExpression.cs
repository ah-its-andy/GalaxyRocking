namespace GalaxyRocking.Expressions
{
    /// <summary>
    /// 数学表达式
    /// </summary>
    public abstract class ArithmeticExpression : Expression
    {
        /// <summary>
        /// 表示值为0的数学表达式
        /// </summary>
        public readonly static ArithmeticExpression Zero = new ZeroExpression();

        /// <summary>
        /// 数学表达式左侧的元素
        /// </summary>
        public abstract ArithmeticExpression Left { get; }
        /// <summary>
        /// 数学表达式右侧的元素
        /// </summary>
        public abstract ArithmeticExpression Right { get; }
        /// <summary>
        /// 数学表达式的类型
        /// </summary>
        public abstract ArithmeticTypes ArithmeticType { get; }
        
        /// <summary>
        /// 值为0的表达式
        /// </summary>
        private class ZeroExpression : ArithmeticExpression
        {
            public override ArithmeticExpression Left => null;

            public override ArithmeticExpression Right => null;

            public override ArithmeticTypes ArithmeticType => ArithmeticTypes.Zero;
        }
    }
}
