using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;

public interface IMotherboard
{
    public MotherboardSpecificator MotherBoardSpecification { get; set; }
}