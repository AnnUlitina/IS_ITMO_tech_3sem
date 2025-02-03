using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnits.Builders;

public class PowerUnitBuilder : PowerUnitBuilderBase
{
    protected override IPowerUnit Create(PowerUnitSpecificator powerUnitSpecificator)
    {
        return new PowerUnit(powerUnitSpecificator);
    }
}