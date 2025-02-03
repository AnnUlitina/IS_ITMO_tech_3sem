using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMPProfiles;

public class XMPProfile : IXMPProfile
{
    public XMPProfile(XmpProfileSpecificator specificator)
    {
        XmpProfileSpecification = specificator;
    }

    public XmpProfileSpecificator XmpProfileSpecification { get; set; }
}