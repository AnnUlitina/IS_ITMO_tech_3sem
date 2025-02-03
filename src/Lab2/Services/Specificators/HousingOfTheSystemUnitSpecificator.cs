using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

public class HousingOfTheSystemUnitSpecificator
{
    protected internal HousingOfTheSystemUnitSpecificator()
    {
        string str = string.Empty;
        Name = str;
        WidthVideoCard = str;
        HightVideoCard = str;
        OverallDimensions = str;
        MotherboardsSupportedFormFactors = new List<string>();
        HousingOfTheSystemUnitType = str;
    }

    protected internal HousingOfTheSystemUnitSpecificator(
        string name,
        string widthVideoCard,
        string hightVideoCard,
        string overallDimensions,
        IEnumerable<string> motherboardsSupportedFormFactors,
        string housingOfTheSystemUnitType)
    {
        Name = name;
        WidthVideoCard = widthVideoCard;
        HightVideoCard = hightVideoCard;
        OverallDimensions = overallDimensions;
        MotherboardsSupportedFormFactors = motherboardsSupportedFormFactors;
        HousingOfTheSystemUnitType = housingOfTheSystemUnitType;
    }

    public string Name { get; set; }
    public string WidthVideoCard { get; set; }
    public string HightVideoCard { get; set; }
    public string OverallDimensions { get; set; }
    public IEnumerable<string> MotherboardsSupportedFormFactors { get; set; }
    public string HousingOfTheSystemUnitType { get; set; }
}