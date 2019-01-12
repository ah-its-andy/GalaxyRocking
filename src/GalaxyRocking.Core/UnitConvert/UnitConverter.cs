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
            var unitDescriptor
                = _galaxyRockingOptions
                    .UnitConvertOptions.UnitConvertDescriptors
                      .FirstOrDefault(x => x.UnitName == sourceUnit);
            if(unitDescriptor == null)
            {
                ConsolePrinter.PrintResult($"Unit {sourceUnit} was unsupported.");
                return 0;
            }
            var singleUnit = (double)unitDescriptor.CreaditAmount / unitDescriptor.UnitAmount;
            return System.Convert.ToUInt32(Math.Round(amount * singleUnit));
        }
    }
}
