namespace GalaxyRocking.Expressions
{
    /// <summary>
    /// 字符数字表达式，用于表示罗马字符
    /// </summary>
    public class SymbolExpression : UInt32Expression
    {
        /// <summary>
        /// 实例化一个字符数字表达式
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="value"></param>
        public SymbolExpression(char symbol, uint value) : base(value)
        {
            Symbol = symbol;
        }

        /// <summary>
        /// 字符
        /// </summary>
        public char Symbol { get; }
    }
}
