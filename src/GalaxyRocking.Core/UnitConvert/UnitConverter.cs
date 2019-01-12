using System;
using System.Linq;

namespace GalaxyRocking.UnitConvert
{
    /// <summary>
    /// 单位转换器
    /// </summary>
    public class UnitConverter : IUnitConverter
    {
        private readonly GalaxyRockingOptions _galaxyRockingOptions;

        public UnitConverter(GalaxyRockingOptions galaxyRockingOptions)
        {
            _galaxyRockingOptions = galaxyRockingOptions ?? throw new ArgumentNullException(nameof(galaxyRockingOptions));
        }

        public uint Convert(uint amount, string sourceUnit, string targetUnit)
        {
            var sourceUnitDescriptor
                = _galaxyRockingOptions
                    .UnitConvertOptions.UnitConvertDescriptors
                      .FirstOrDefault(x => x.UnitName == sourceUnit);
            if(sourceUnitDescriptor == null)
            {
                ConsolePrinter.PrintResult($"Unit {sourceUnit} was unsupported.");
                return 0;
            }
            var singleUnit = (double)sourceUnitDescriptor.CreditAmount / sourceUnitDescriptor.UnitAmount;
            var credits = amount * singleUnit;
            if(targetUnit == "Credits")
                return System.Convert.ToUInt32(Math.Round(credits));

            var targetUnitDescriptor
                = _galaxyRockingOptions
                    .UnitConvertOptions.UnitConvertDescriptors
                      .FirstOrDefault(x => x.UnitName == targetUnit);

            if (targetUnitDescriptor == null)
            {
                ConsolePrinter.PrintResult($"Unit {targetUnit} was unsupported.");
                return 0;
            }

            singleUnit = 0;
            singleUnit = (double)targetUnitDescriptor.UnitAmount / targetUnitDescriptor.CreditAmount;
            var targetAmount = singleUnit * credits;
            return System.Convert.ToUInt32(Math.Round(targetAmount));

        }
    }
}
