namespace GalaxyRocking.UnitConvert
{
    public interface IUnitConverter
    {
        uint Convert(uint amount, string sourceUnit, string targetUnit);
    }
}
