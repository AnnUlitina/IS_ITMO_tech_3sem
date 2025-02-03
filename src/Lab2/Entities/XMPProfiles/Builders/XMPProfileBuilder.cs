using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMPProfiles.Builders;

public class XMPProfileBuilder : XMPProfileBuilderBase
{
    protected override IXMPProfile Create(XmpProfileSpecificator xmpProfileSpecificator)
    {
        return new XMPProfile(xmpProfileSpecificator);
    }
}