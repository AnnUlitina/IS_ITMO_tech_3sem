using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMPProfiles;

public interface IXMPProfile
{
    public XmpProfileSpecificator XmpProfileSpecification { get; set; }
}