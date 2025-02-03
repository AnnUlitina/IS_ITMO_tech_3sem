using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMPProfiles;

public interface IXMPProfileBuilder
{
    IXMPProfileBuilder WithTiming(string timing);
    IXMPProfileBuilder WithVoltage(string voltage);
    IXMPProfileBuilder WithFrequency(string frequency);
    IXMPProfileBuilder Direct(XmpProfileSpecificator xmpProfileSpecificator);
    IXMPProfile Build();
}