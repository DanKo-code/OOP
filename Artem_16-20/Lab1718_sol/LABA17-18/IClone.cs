using LABA17_18.Abstaract_Factory;

namespace LABA17_18
{
    public interface IClone
    {
        string GetName();
        ITotalCost GetCostProduct();
        double GetCost();
        IClone Clone();
    }
}
