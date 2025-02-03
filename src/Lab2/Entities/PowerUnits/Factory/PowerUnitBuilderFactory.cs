using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnits.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnits.Factory;

public class PowerUnitBuilderFactory : IPowerUnitBuilderFactory
{
    public IPowerUnitBuilder Create()
    {
        return new PowerUnitBuilder();
    }
}