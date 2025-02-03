using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HousingOfTheSystemUnits.Builders;

public abstract class HousingOfTheSystemUnitBuilderBase : IHousingOfTheSystemUnitsBuilder
{
    private HousingOfTheSystemUnitSpecificator _housingOfTheSystemUnitSpecificator;

    protected HousingOfTheSystemUnitBuilderBase()
    {
        _housingOfTheSystemUnitSpecificator = new HousingOfTheSystemUnitSpecificator();
    }

    public IHousingOfTheSystemUnitsBuilder WithOverallDiemensions(string overallDimensions)
    {
        _housingOfTheSystemUnitSpecificator.OverallDimensions = overallDimensions;
        return this;
    }

    public IHousingOfTheSystemUnitsBuilder WithWidthVideoCard(string widthVideoCard)
    {
        _housingOfTheSystemUnitSpecificator.WidthVideoCard = widthVideoCard;
        return this;
    }

    public IHousingOfTheSystemUnitsBuilder WithHightVideoCard(string hightVideoCard)
    {
        _housingOfTheSystemUnitSpecificator.HightVideoCard = hightVideoCard;
        return this;
    }

    public IHousingOfTheSystemUnitsBuilder WithMotherboardsSupportedFormFactors(
        IEnumerable<string> motherboardsSupportedFormFactors)
    {
        _housingOfTheSystemUnitSpecificator.MotherboardsSupportedFormFactors =
            motherboardsSupportedFormFactors;
        return this;
    }

    public IHousingOfTheSystemUnitsBuilder WithHousingOfTheSystemUnitType(
        string housingOfTheSystemUnitType)
    {
        _housingOfTheSystemUnitSpecificator.HousingOfTheSystemUnitType = housingOfTheSystemUnitType;
        return this;
    }

    public IHousingOfTheSystemUnitsBuilder WithName(string name)
    {
        _housingOfTheSystemUnitSpecificator.Name = name;
        return this;
    }

    public IHousingOfTheSystemUnitsBuilder Direct(HousingOfTheSystemUnitSpecificator housingOfTheSystemUnitSpecificator)
    {
        WithOverallDiemensions(housingOfTheSystemUnitSpecificator.OverallDimensions);
        WithWidthVideoCard(housingOfTheSystemUnitSpecificator.WidthVideoCard);
        WithHightVideoCard(housingOfTheSystemUnitSpecificator.HightVideoCard);
        WithMotherboardsSupportedFormFactors(housingOfTheSystemUnitSpecificator.MotherboardsSupportedFormFactors);
        WithHousingOfTheSystemUnitType(housingOfTheSystemUnitSpecificator.HousingOfTheSystemUnitType);
        WithName(housingOfTheSystemUnitSpecificator.Name);
        return this;
    }

    public IHousingOfTheSystemUnit Build()
    {
        return Create(_housingOfTheSystemUnitSpecificator);
    }

    protected abstract IHousingOfTheSystemUnit Create(HousingOfTheSystemUnitSpecificator housingOfTheSystemUnitSpecificator);
}