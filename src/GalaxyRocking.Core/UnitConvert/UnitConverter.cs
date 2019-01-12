using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyRocking.UnitConvert
{
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
            var singleUnit = (double)sourceUnitDescriptor.CreaditAmount / sourceUnitDescriptor.UnitAmount;
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
            singleUnit = (double)targetUnitDescriptor.UnitAmount / targetUnitDescriptor.CreaditAmount;
            var targetAmount = singleUnit * credits;
            return System.Convert.ToUInt32(Math.Round(targetAmount));

        }
    }
}
