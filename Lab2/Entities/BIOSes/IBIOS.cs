using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSes;

public interface IBios
{
    public BiosSpecificator BiosSpecification { get; set; }
}