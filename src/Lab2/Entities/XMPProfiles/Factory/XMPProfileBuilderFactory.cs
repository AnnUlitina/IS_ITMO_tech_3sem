using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMPProfiles.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMPProfiles.Factory;

public class XMPProfileBuilderFactory : IXMPProfileBuilderFactory
{
    public IXMPProfileBuilder Create()
    {
        return new XMPProfileBuilder();
    }
}