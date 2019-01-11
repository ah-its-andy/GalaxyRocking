using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyRocking.Expressions
{
    public class GalaxyExpression : Expression
    {
        public GalaxyExpression(Expression body)
        {
            Body = body ?? throw new ArgumentNullException(nameof(body));
        }

        public Expression Body { get; }

        public Delegate Compile() => GetDelegate((ArithmeticExpression)Body);

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
                    if (expression is ConstantExpression constExpr)
                        return constExpr.Symbol.ToString();
                    else if (expression is UInt32Expression uInt32Expression)
                        return uInt32Expression.Value.ToString();
                    return string.Empty;

                case ArithmeticTypes.Zero:
                    return string.Empty;
            }
            return string.Join("+", strs.Where(x => !string.IsNullOrEmpty(x)));
        }

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
