using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HousingOfTheSystemUnits;

public interface IHousingOfTheSystemUnitsBuilder
{
    public IHousingOfTheSystemUnitsBuilder WithOverallDiemensions(string overallDimensions);

    public IHousingOfTheSystemUnitsBuilder WithWidthVideoCard(string widthVideoCard);

    public IHousingOfTheSystemUnitsBuilder WithHightVideoCard(string hightVideoCard);

    public IHousingOfTheSystemUnitsBuilder WithMotherboardsSupportedFormFactors(
        IEnumerable<string> motherboardsSupportedFormFactors);

    public IHousingOfTheSystemUnitsBuilder WithHousingOfTheSystemUnitType(
        string housingOfTheSystemUnitType);

    public IHousingOfTheSystemUnitsBuilder WithName(string name);

    public IHousingOfTheSystemUnitsBuilder
        Direct(HousingOfTheSystemUnitSpecificator housingOfTheSystemUnitSpecificator);
    IHousingOfTheSystemUnit Build();
}