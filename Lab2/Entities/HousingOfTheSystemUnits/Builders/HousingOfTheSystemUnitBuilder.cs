using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HousingOfTheSystemUnits.Builders;

public class HousingOfTheSystemUnitBuilder : HousingOfTheSystemUnitBuilderBase
{
    protected override IHousingOfTheSystemUnit Create(
        HousingOfTheSystemUnitSpecificator housingOfTheSystemUnitSpecificator)
    {
        return new HousingOfTheSystemUnit(housingOfTheSystemUnitSpecificator);
    }
}