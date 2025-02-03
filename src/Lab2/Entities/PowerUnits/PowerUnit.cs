using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnits;

public class PowerUnit : IPowerUnit
{
    public PowerUnit(PowerUnitSpecificator powerUnitSpecification)
    {
        PowerUnitSpecification = powerUnitSpecification;
    }

    public PowerUnitSpecificator PowerUnitSpecification { get; set; }
}