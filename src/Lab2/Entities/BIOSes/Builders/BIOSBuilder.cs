using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSes.Builders;

public class BiosBuilder : BiosBuilderBase
{
    protected override IBios Create(BiosSpecificator biosSpecificator)
    {
        return new Bios(biosSpecificator);
    }
}