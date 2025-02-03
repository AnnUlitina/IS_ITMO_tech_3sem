using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnits;

public interface IPowerUnitBuilder
{
    public IPowerUnitBuilder WithPeakLoad(string peakLoad);
    public IPowerUnitBuilder WithName(string name);
    public IPowerUnitBuilder Direct(PowerUnitSpecificator powerUnitSpecificator);
    IPowerUnit Build();
}