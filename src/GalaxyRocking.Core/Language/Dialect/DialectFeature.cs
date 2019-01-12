using System;

namespace GalaxyRocking.Language.Dialect
{
    /// <summary>
    /// 方言特征
    /// </summary>
    public class DialectFeature
    {
        public DialectFeature(string expression, bool useRegular, SyntaxTypes syntaxType)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            UseRegular = useRegular;
            SyntaxType = syntaxType;
        }
        /// <summary>
        /// 特征表达式
        /// </summary>
        public string Expression { get; }
        /// <summary>
        /// 是否是正则表达式
        /// </summary>
        public bool UseRegular { get; }
        /// <summary>
        /// 语法类型
        /// </summary>
        public SyntaxTypes SyntaxType { get; }
    }
}
