using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnits.Builders;

public abstract class PowerUnitBuilderBase : IPowerUnitBuilder
{
    private PowerUnitSpecificator _powerUnitSpecificator;
    protected PowerUnitBuilderBase()
    {
        _powerUnitSpecificator = new PowerUnitSpecificator();
    }

    public IPowerUnitBuilder WithPeakLoad(string peakLoad)
    {
        _powerUnitSpecificator.PeakLoad = peakLoad;
        return this;
    }

    public IPowerUnitBuilder WithName(string name)
    {
        _powerUnitSpecificator.Name = name;
        return this;
    }

    public IPowerUnitBuilder Direct(PowerUnitSpecificator powerUnitSpecificator)
    {
        WithName(powerUnitSpecificator.Name);
        WithPeakLoad(powerUnitSpecificator.PeakLoad);
        return this;
    }

    public IPowerUnit Build()
    {
        return Create(_powerUnitSpecificator);
    }

    protected abstract IPowerUnit Create(PowerUnitSpecificator powerUnitSpecificator);
}