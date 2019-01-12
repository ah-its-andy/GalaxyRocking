using System.Collections.Generic;

namespace GalaxyRocking.Expressions
{
    /// <summary>
    /// 字符解析器，用于处理相邻的两个表达式
    /// </summary>
    public interface ISymbolResolver
    {
        /// <summary>
        /// 两个表达式之间是否有关联
        /// </summary>
        bool CanResolve(Expression current, Expression next);
        /// <summary>
        /// 解析两个表达式的关系
        /// </summary>
        /// <param name="current">当前表达式</param>
        /// <param name="next">下一个表达式</param>
        /// <returns>[0]处理完成的表达式，如果两个表达式之间没有关系，则为current；[1]应该返回null，如果两个表达式之间没有关系，则为next.</returns>
        (Expression, Expression) Resolve(Expression current, Expression next);
    }
}
