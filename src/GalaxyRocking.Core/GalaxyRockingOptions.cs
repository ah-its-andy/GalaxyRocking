using GalaxyRocking.Language.Dialect;
using GalaxyRocking.Symbol;
using GalaxyRocking.UnitConvert;

namespace GalaxyRocking
{
    public class GalaxyRockingOptions
    {
        public SymbolMappingOptions SymbolMappingOptions { get; } = new SymbolMappingOptions();
        public DialectOptions DialectOptions { get; } = new DialectOptions();
        public UnitConvertOptions UnitConvertOptions { get; } = new UnitConvertOptions();
    }
}
