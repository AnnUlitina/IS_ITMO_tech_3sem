using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HousingOfTheSystemUnits;

public interface IHousingOfTheSystemUnit
{
    public HousingOfTheSystemUnitSpecificator HousingOfTheSystemUnitSpecification { get; set; }
}