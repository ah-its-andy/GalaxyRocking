using System;

namespace GalaxyRocking.UnitConvert
{
    /// <summary>
    /// 单位转换描述
    /// </summary>
    public class UnitConvertDescriptor
    {
        public UnitConvertDescriptor(uint unitAmount, string unitName, uint creaditAmount)
        {
            UnitAmount = unitAmount;
            UnitName = unitName ?? throw new ArgumentNullException(nameof(unitName));
            CreditAmount = creaditAmount;
        }

        /// <summary>
        /// 当前单位数量
        /// </summary>
        public uint UnitAmount { get; }
        /// <summary>
        /// 当前单位名称
        /// </summary>
        public string UnitName { get; }
        /// <summary>
        /// 对应的Credit单位数量
        /// </summary>
        public uint CreditAmount { get; }
    }
}
