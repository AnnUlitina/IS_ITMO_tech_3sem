using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMPProfiles.Builders;

public abstract class XMPProfileBuilderBase : IXMPProfileBuilder
{
    private XmpProfileSpecificator _xmpProfileSpecificator;

    protected XMPProfileBuilderBase()
    {
        _xmpProfileSpecificator = new XmpProfileSpecificator();
    }

    public IXMPProfileBuilder WithTiming(string timing)
    {
        _xmpProfileSpecificator.Timing = timing;
        return this;
    }

    public IXMPProfileBuilder WithVoltage(string voltage)
    {
        _xmpProfileSpecificator.Voltage = voltage;
        return this;
    }

    public IXMPProfileBuilder WithFrequency(string frequency)
    {
        _xmpProfileSpecificator.Frequency = frequency;
        return this;
    }

    public IXMPProfileBuilder Direct(XmpProfileSpecificator xmpProfileSpecificator)
    {
        WithTiming(xmpProfileSpecificator.Timing);
        WithVoltage(xmpProfileSpecificator.Voltage);
        WithFrequency(xmpProfileSpecificator.Frequency);
        return this;
    }

    public IXMPProfile Build()
    {
        return Create(_xmpProfileSpecificator);
    }

    protected abstract IXMPProfile Create(XmpProfileSpecificator xmpProfileSpecificator);
}