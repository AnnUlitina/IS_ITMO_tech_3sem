using Itmo.ObjectOrientedProgramming.Lab2.Entities.HousingOfTheSystemUnits.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HousingOfTheSystemUnits.Factory;

public class HousingOfTheSystemUnitBuilderFactory : IHousingOfTheSystemUnitsBuilderFactory
{
    public IHousingOfTheSystemUnitsBuilder Create()
    {
        return new HousingOfTheSystemUnitBuilder();
    }
}