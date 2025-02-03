using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnits;

public interface IPowerUnit
{
    public PowerUnitSpecificator PowerUnitSpecification { get; set; }
}