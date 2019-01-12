using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyRocking.Expressions
{
    /// <summary>
    /// 银河系表达式，用于处理数学表达式的容器
    /// </summary>
    public class GalaxyExpression : Expression
    {
        /// <summary>
        /// 实例化一个银河系表达式对象
        /// </summary>
        /// <param name="body">内部表达式主体</param>
        public GalaxyExpression(Expression body)
        {
            Body = body ?? throw new ArgumentNullException(nameof(body));
        }

        /// <summary>
        /// 主体表达式
        /// </summary>
        public Expression Body { get; }

        /// <summary>
        /// 将表达式编译成一个可执行的委托类型
        /// </summary>
        /// <returns></returns>
        public Delegate Compile() => GetDelegate((ArithmeticExpression)Body);

        /// <summary>
        /// 递归生成委托类型
        /// </summary>
        /// <param name="expression">数学表达式</param>
        /// <returns></returns>
        private Func<uint> GetDelegate(ArithmeticExpression expression)
        {
            var delegates = new List<Func<uint>>();
            switch (expression.ArithmeticType)
            {
                case ArithmeticTypes.Addition:
                    delegates.Add(GetDelegate(expression.Left));
                    delegates.Add(GetDelegate(expression.Right));
                    break;

                case ArithmeticTypes.Multiplication:
                    delegates.Add(() => GetDelegate(expression.Left)() * GetDelegate(expression.Right)());
                    break;

                case ArithmeticTypes.Subtraction:
                    delegates.Add(() => GetDelegate(expression.Right)() - GetDelegate(expression.Left)());
                    break;

                case ArithmeticTypes.UInt32:
                    if (expression is UInt32Expression uInt32Expression)
                        return () => uInt32Expression.Value;
                    return () => 0;

                case ArithmeticTypes.Zero:
                    return () => 0;
            }

            return () => (uint)delegates.Sum(x => x());
        }


        public string ToString(string format)
        {
            if (format == "S") return GetSymbolString((ArithmeticExpression)Body);
            else if (format == "N") return GetDigitString((ArithmeticExpression)Body);
            return base.ToString();
        }

        public override string ToString()
        {
            return ToString("N");
        }

        /// <summary>
        /// 获取一个字符串形式的表达式
        /// </summary>
        private string GetSymbolString(ArithmeticExpression expression)
        {
            var strs = new List<string>();
            switch (expression.ArithmeticType)
            {
                case ArithmeticTypes.Addition:
                    strs.Add(GetSymbolString(expression.Left));
                    strs.Add(GetSymbolString(expression.Right));
                    break;

                case ArithmeticTypes.Multiplication:
                    strs.Add($"({GetSymbolString(expression.Left)}*{GetSymbolString(expression.Right)})");
                    break;

                case ArithmeticTypes.Subtraction:
                    strs.Add($"({GetSymbolString(expression.Right)}-{GetSymbolString(expression.Left)})");
                    break;

                case ArithmeticTypes.UInt32:
                    if (expression is SymbolExpression constExpr)
                        return constExpr.Symbol.ToString();
                    else if (expression is UInt32Expression uInt32Expression)
                        return uInt32Expression.Value.ToString();
                    return string.Empty;

                case ArithmeticTypes.Zero:
                    return string.Empty;
            }
            return string.Join("+", strs.Where(x => !string.IsNullOrEmpty(x)));
        }

        /// <summary>
        /// 获取一个字符串形式的表达式
        /// </summary>
        private string GetDigitString(ArithmeticExpression expression)
        {
            var strs = new List<string>();

            switch (expression.ArithmeticType)
            {
                case ArithmeticTypes.Addition:
                    strs.Add(GetDigitString(expression.Left));
                    strs.Add(GetDigitString(expression.Right));
                    break;

                case ArithmeticTypes.Multiplication:
                    strs.Add($"({GetDigitString(expression.Left)}*{GetDigitString(expression.Right)})");
                    break;

                case ArithmeticTypes.Subtraction:
                    strs.Add($"({GetDigitString(expression.Right)}-{GetDigitString(expression.Left)})");
                    break;

                case ArithmeticTypes.UInt32:
                    if (expression is UInt32Expression uInt32Expression)
                        return uInt32Expression.Value.ToString();
                    return string.Empty;

                case ArithmeticTypes.Zero:
                    return string.Empty;
            }

            return string.Join("+", strs.Where(x => !string.IsNullOrEmpty(x)));
        }
    }
}
