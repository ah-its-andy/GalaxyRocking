using System.Collections.Generic;

namespace GalaxyRocking.Symbol
{
    public class SymbolMappingService : ISymbolMappingService
    {
        private readonly Dictionary<char, uint> symbolMap;

        public SymbolMappingService(GalaxyRockingOptions options)
        {
            symbolMap = new Dictionary<char, uint>
            {
                [Symbols.I] = options.SymbolMappingOptions.I,
                [Symbols.V] = options.SymbolMappingOptions.V,
                [Symbols.X] = options.SymbolMappingOptions.X,
                [Symbols.L] = options.SymbolMappingOptions.L,
                [Symbols.C] = options.SymbolMappingOptions.C,
                [Symbols.D] = options.SymbolMappingOptions.D,
                [Symbols.M] = options.SymbolMappingOptions.M
            };
        }

        public uint GetDigitBySymbol(char symbol)
        {
            return symbolMap[symbol];
        }
    }
}
