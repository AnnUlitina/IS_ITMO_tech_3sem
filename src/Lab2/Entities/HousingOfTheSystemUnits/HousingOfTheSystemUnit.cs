using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HousingOfTheSystemUnits;

public class HousingOfTheSystemUnit : IHousingOfTheSystemUnit
{
    public HousingOfTheSystemUnit(
        HousingOfTheSystemUnitSpecificator housingOfTheSystemUnitSpecificator)
    {
        HousingOfTheSystemUnitSpecification = housingOfTheSystemUnitSpecificator;
    }

    public HousingOfTheSystemUnitSpecificator HousingOfTheSystemUnitSpecification { get; set; }
}