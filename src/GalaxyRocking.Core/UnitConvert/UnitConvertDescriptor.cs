using System;

namespace GalaxyRocking.UnitConvert
{
    public class UnitConvertDescriptor
    {
        public UnitConvertDescriptor(uint unitAmount, string unitName, uint creaditAmount)
        {
            UnitAmount = unitAmount;
            UnitName = unitName ?? throw new ArgumentNullException(nameof(unitName));
            CreaditAmount = creaditAmount;
        }

        public uint UnitAmount { get; }
        public string UnitName { get; }
        public uint CreaditAmount { get; }
    }
}
