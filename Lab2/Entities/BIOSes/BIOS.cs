using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSes;

public class Bios : IBios
{
    protected internal Bios(BiosSpecificator specificator)
    {
        BiosSpecification = specificator;
    }

    public BiosSpecificator BiosSpecification { get; set; }
}